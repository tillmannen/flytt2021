
using flytt2021.Data.Database;
using flytt2021.Data.Entities;
using Microsoft.AspNetCore.Http;
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




    }
}
