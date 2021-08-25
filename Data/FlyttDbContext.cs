using Microsoft.EntityFrameworkCore;

namespace flytt2021.Data
{
    public class FlyttDbContext : DbContext
    {
        public FlyttDbContext(DbContextOptions<FlyttDbContext> options) : base(options)
        {

        }

        public DbSet<Movingbox> Movingboxes { get; set; }
        public DbSet<BoxOwner> BoxOwners { get; set; }

    }
}
