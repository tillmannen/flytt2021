using flytt2021.Data.Database;
using flytt2021.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace flytt2021.Data.Services
{
    public class MoveService
    {
        private readonly FlyttDbContext _dbContext;
        private readonly UserService _userService;

        public MoveService(FlyttDbContext dbContext, UserService userService)
        {
            _dbContext = dbContext;
            _userService = userService;
        }


        public async Task<Move> SaveMoveAsync(Move move, FlyttUser owner)
        {
            if(move.MoveId != 0)
            {
                var dbMove = _dbContext.Moves.FirstOrDefault(m => m.MoveId == move.MoveId);
                if (dbMove.CreatedByUserName != owner.Id)
                    return null;
            }
            move.CreatedByUserName = owner.Id;
            var newMove = _dbContext.Moves.Add(move);
            await _dbContext.SaveChangesAsync();

            return newMove.Entity;
        }

        public Move GetMove(int moveid)
        {
            return _dbContext.Moves.FirstOrDefault(m => m.MoveId == moveid);
        }


        public IEnumerable<BoxOwner> GetBoxOwners(string userId)
        {
            var currentUser = _userService.GetUser(userId);
            return _dbContext.BoxOwners/*.Where(bo => bo.MoveId == currentUser.MoveId)*/.ToList();
        }
        public async Task AddBoxOwnerAsync(BoxOwner boxOwner)
        {
            if (!_dbContext.BoxOwners.Any(bo => bo.Name == boxOwner.Name))
            {
                await _dbContext.BoxOwners.AddAsync(boxOwner);
                await _dbContext.SaveChangesAsync();
            }
        }

        public IEnumerable<Packer> GetPackers(string userId)
        {
            var currentUser = _userService.GetUser(userId);
            return _dbContext.Packers/*.Where(mb => mb.MoveId == currentUser.MoveId)*/.ToList();
        }
        public async Task AddPackerAsync(Packer packer)
        {
            if (!_dbContext.Packers.Any(bo => bo.Name == packer.Name))
            {
                await _dbContext.Packers.AddAsync(packer);
                await _dbContext.SaveChangesAsync();
            }
        }
        public IQueryable<DestinationFloor> GetDestinationFloors(string userId)
        {
            var currentUser = _userService.GetUser(userId);
            return _dbContext.DestinationFloors.Where(mb => mb.MoveId == currentUser.MoveId);
        }
        public async Task<DestinationFloor> AddDestinationFloorAsync(DestinationFloor floor)
        {
            if (!_dbContext.DestinationFloors.Any(bo => bo.Name == floor.Name))
            {
                var addedFloor = await _dbContext.DestinationFloors.AddAsync(floor);
                await _dbContext.SaveChangesAsync();

                return addedFloor.Entity;
            }

            return null;
        }
    }
}
