using flytt2021.Data.Database;
namespace flytt2021.Data.Services;

public class UserService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    public List<FlyttUser> GetAllUsers()
    {
        return _context.Users.ToList();
    }

    public FlyttUser GetUser(string userName)
    {
        return _context.Users.FirstOrDefault(u => u.UserName == userName);
    }

    public async Task UpdateUserAsync(FlyttUser user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

}