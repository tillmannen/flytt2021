
using flytt2021.Data.Database;
using flytt2021.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Data.Services
{
    public class MovingboxService
    {
        private readonly FlyttDbContext _dbContext;

        public MovingboxService(FlyttDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Movingbox>> GetMovingboxesAsync()
        {
            return await _dbContext.Movingboxes.Include(mb => mb.DestinationFloor).ToListAsync();
        }
        public async Task<Movingbox> GetMovingboxAsync(int id)
        {
            var box = await _dbContext.Movingboxes
                .Include(mb => mb.DestinationFloor)
                .Include(mb => mb.Packer)
                .Include(mb => mb.BoxOwner)
                .Include(mb => mb.Move)
                .FirstOrDefaultAsync(b => b.MovingboxId == id);

            return box;
        }
        public async Task<int> SaveMovingboxAsync(Movingbox newbox)
        {
            if (newbox.MovingboxId != 0)
                _dbContext.Movingboxes.Update(newbox);
            else
                await _dbContext.Movingboxes.AddAsync(newbox);
            _dbContext.SaveChanges();

            return newbox.MovingboxId;
        }



        public IEnumerable<BoxOwner> GetBoxOwners()
        {
            return _dbContext.BoxOwners.ToList();
        }
        public async Task AddBoxOwnerAsync(BoxOwner boxOwner)
        {
            if (!_dbContext.BoxOwners.Any(bo => bo.Name == boxOwner.Name))
            {
                await _dbContext.BoxOwners.AddAsync(boxOwner);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Packer> GetPackers()
        {
            return _dbContext.Packers.ToList();
        }
        public async Task AddPackerAsync(Packer packer)
        {
            if (!_dbContext.Packers.Any(bo => bo.Name == packer.Name))
            {
                await _dbContext.Packers.AddAsync(packer);
                await _dbContext.SaveChangesAsync();
            }
        }
        public IQueryable<DestinationFloor> GetDestinationFloors()
        {
            return _dbContext.DestinationFloors.Where(d => true);
        }
        public async Task AddDestinationFloorAsync(DestinationFloor floor)
        {
            if (!_dbContext.DestinationFloors.Any(bo => bo.Name == floor.Name))
            {
                await _dbContext.DestinationFloors.AddAsync(floor);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
