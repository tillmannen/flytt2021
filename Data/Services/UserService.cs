using flytt2021.Data.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace flytt2021.Data.Services
{
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
        public string CurrentUserName
        {
            get
            {
                try
                {
                    return _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                }
                catch
                {
                    return "";
                }
                
            }
        }

    }
}
