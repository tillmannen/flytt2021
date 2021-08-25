
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Data
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
            return await _dbContext.Movingboxes.ToListAsync();
        }
        public async Task<int> AddMovingboxAsync(Movingbox newbox)
        {
            await _dbContext.Movingboxes.AddAsync(newbox);
            _dbContext.SaveChanges();

            return newbox.Id;
        }



        public async Task<IEnumerable<BoxOwner>> GetBoxOwnersAsync()
        {
            return await _dbContext.BoxOwners.ToListAsync();
        }
        public async Task AddBoxOwnerAsync(BoxOwner boxOwner)
        {
            if(!_dbContext.BoxOwners.Any(bo => bo.Name == boxOwner.Name))
                await _dbContext.BoxOwners.AddAsync(boxOwner);
        }
    }
}
