using flytt2021.Data.Database;
using flytt2021.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace flytt2021.Data.Services;

public class MovingboxService
{
    private readonly FlyttDbContext _dbContext;
    private readonly UserService _userService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public MovingboxService(FlyttDbContext dbContext, UserService userService, IHttpContextAccessor httpContextAccessor)
    {
        _dbContext = dbContext;
        _userService = userService;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<IEnumerable<Movingbox>> GetMovingboxesAsync(string userName = null)
    {
        if(userName != null)
        {
            var user = _userService.GetUser(userName);
            return await _dbContext.Movingboxes.Where(mb => mb.MoveId == user.MoveId)
            .Include(mb => mb.DestinationFloor)
            .Include(mb => mb.Packer)
            .Include(mb => mb.BoxOwner)
            .Include(mb => mb.Move)
            .ToListAsync();
        }
        return new List<Movingbox>();
    }
    public async Task<Movingbox> GetMovingboxAsync(string userName, int id)
    {
        if (userName != null)
        {
            var user = _userService.GetUser(userName);
            var box = await _dbContext.Movingboxes
            .Include(mb => mb.DestinationFloor)
            .Include(mb => mb.Packer)
            .Include(mb => mb.BoxOwner)
            .Include(mb => mb.Move)
            .FirstOrDefaultAsync(b => b.MovingboxId == id && b.MoveId == user.MoveId);

            return box;
        }
        return new Movingbox();
    }
    public async Task<int> SaveMovingboxAsync(Movingbox newbox)
    {
        if(newbox.Number == 0)
            newbox.Number = _dbContext.Movingboxes.Where(mb => mb.MoveId == newbox.MoveId).OrderByDescending(mb => mb.Number).FirstOrDefault().Number + 1;

        if (newbox.MovingboxId != 0)
            _dbContext.Movingboxes.Update(newbox);
        else
            await _dbContext.Movingboxes.AddAsync(newbox);
        
        _dbContext.SaveChanges();

        return newbox.MovingboxId;
    }




}