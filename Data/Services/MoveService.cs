using flytt2021.Data.Database;
using flytt2021.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace flytt2021.Data.Services;

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
        EntityEntry<Move> newMove;
        if(move.MoveId != 0)
        {
            var dbMove = _dbContext.Moves.FirstOrDefault(m => m.MoveId == move.MoveId);
            if (dbMove.CreatedByUserName != owner.Id)
                return null;
            newMove = _dbContext.Moves.Update(move);
        }
        else 
        {
            move.CreatedByUserName = owner.Email;
            newMove = _dbContext.Moves.Add(move);
        }
        await _dbContext.SaveChangesAsync();

        return newMove.Entity;
    }

    public Move GetMove(int moveid)
    {
        var move = _dbContext.Moves
            .FirstOrDefault(m => m.MoveId == moveid);
        return move;
    }

    public Move GetFullMove(int moveid)
    {
        var move = _dbContext.Moves
            .Include(df => df.DestinationFloors)
            .Include(p => p.Packers)
            .Include(bo => bo.BoxOwners)
            .Include(mb => mb.MovingBoxes)
            .FirstOrDefault(m => m.MoveId == moveid);
        return move;
    }


    public IEnumerable<BoxOwner> GetBoxOwners(string userId)
    {
        var currentUser = _userService.GetUser(userId);
        return _dbContext.BoxOwners.Where(bo => bo.MoveId == currentUser.MoveId).ToList();
    }
    public async Task<BoxOwner> AddBoxOwnerAsync(BoxOwner boxOwner)
    {
        if (!_dbContext.BoxOwners.Any(bo => bo.MoveId == boxOwner.MoveId && bo.Name == boxOwner.Name) && !string.IsNullOrEmpty(boxOwner.Name))
        {
            var owner = await _dbContext.BoxOwners.AddAsync(boxOwner);
            await _dbContext.SaveChangesAsync();

            return owner.Entity;
        }

        return null;
    }

    public IEnumerable<Packer> GetPackers(string userId)
    {
        var currentUser = _userService.GetUser(userId);
        return _dbContext.Packers.Where(mb => mb.MoveId == currentUser.MoveId).ToList();
    }
    public async Task<Packer> AddPackerAsync(Packer packer)
    {
        if (!_dbContext.Packers.Any(p => p.MoveId == packer.MoveId && p.Name == packer.Name) && !string.IsNullOrEmpty(packer.Name))
        {
            var addedPacker = await _dbContext.Packers.AddAsync(packer);
            await _dbContext.SaveChangesAsync();

            return addedPacker.Entity;
        }
        return null;
    }
    public IQueryable<DestinationFloor> GetDestinationFloors(string userId)
    {
        var currentUser = _userService.GetUser(userId);
        var destinationFloors = _dbContext.DestinationFloors.Where(mb => mb.MoveId == currentUser.MoveId);
        return destinationFloors;
    }
    public async Task<DestinationFloor> AddDestinationFloorAsync(DestinationFloor floor)
    {
        if (!_dbContext.DestinationFloors.Any(df => df.MoveId == floor.MoveId && df.Name == floor.Name) && !string.IsNullOrEmpty(floor.Name))
        {
            var addedFloor = await _dbContext.DestinationFloors.AddAsync(floor);
            await _dbContext.SaveChangesAsync();

            return addedFloor.Entity;
        }

        return null;
    }

    public MoveProgress GetMoveProgress(string userId = null)
    {
        var user = _userService.GetUser(userId);

        var move = GetFullMove(user.MoveId.Value);

        var estCount = move.FromArea.HasValue ? (int)Math.Floor(move.FromArea.Value * 1.5) : 0;
        var currentCount = move.MovingBoxes.Count();

        return new MoveProgress { EstimatedBoxCount = estCount, PackedBoxes = currentCount };
    }
}