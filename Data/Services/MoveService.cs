using flytt2021.Data.Database;
using flytt2021.Data.Entities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace flytt2021.Data.Services;

public class MoveService
{
    private readonly FlyttDbContext _dbContext;
    private readonly UserService _userService;
    private readonly IEmailSender _emailSender;

    public MoveService(FlyttDbContext dbContext, UserService userService, IEmailSender emailSender)
    {
        _dbContext = dbContext;
        _userService = userService;
        _emailSender = emailSender;
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

    public async Task<bool> InviteUserToMoveAsync(UserMoveInvite newUser, FlyttUser invitingUser)
    {
        if(invitingUser.MoveId == null)
            return false;

        newUser.MoveId = invitingUser.MoveId.Value;
        newUser.InvitedByUserName = invitingUser.UserName;

        //save to db
        var invitedEntity = _dbContext.Add(newUser);
        await _dbContext.SaveChangesAsync();
        var invited = invitedEntity.Entity;

        // Send user an email
        await _emailSender.SendEmailAsync(newUser.UserName, "Inbjudan till Movable.se", $"Du har blivit inbjuden av {invitingUser.UserName} att använda <a href='https://movable.se/move/acceptInvitation/{newUser.MoveId}'>movable.se</a> och hjälpa dem med flytten.<br /><br /><a href='https://movable.se/move/acceptInvitation/{newUser.MoveId}'>Klicka här</a> för att acceptera inbjudan.<br /><br />Med vänlig hälsning<br/>Vi på movable.se");

        // Create accept invitation page
        
        // Check if user has unanswered invitations on login and if so - redirect to accept invite page

        return true;
    }

    public async Task<UserMoveInvite> GetInvitedUserAsync(string userName)
    {
        return await _dbContext.UserMoveInvites.FirstOrDefaultAsync(u => u.UserName == userName);
    }

    public async Task AcceptUserMoveInvitationAsync(UserMoveInvite invitedUser)
    {
        // Create entry in UserMoves
        _dbContext.UserMoves.Add(new UserMove{ UserName = invitedUser.UserName, MoveId = invitedUser.MoveId});
        
        // Set user.moveid = invitedUser.MoveId
        var user = _userService.GetUser(invitedUser.UserName);
        user.MoveId = invitedUser.MoveId;
        await _userService.UpdateUserAsync(user);

        // send email to inviting user
        await _emailSender.SendEmailAsync(invitedUser.InvitedByUserName, "Inbjudan accepterad", $"Din vän {invitedUser.UserName} har nu accepterat inbjudan till movable.se och kan nu hjälpa dig att registrerta flyttkartonger.<br /><br />Tack för att du använder movable.se!<br /><br />Med vänliga hälsningar<br />Vi på movable.se");

        // remove invitation
        _dbContext.UserMoveInvites.Remove(invitedUser);
    }
}