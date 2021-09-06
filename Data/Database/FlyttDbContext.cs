using flytt2021.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace flytt2021.Data.Database
{
    public class FlyttDbContext : DbContext
    {
        public FlyttDbContext(DbContextOptions<FlyttDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Movingbox> Movingboxes { get; set; }
        public DbSet<BoxOwner> BoxOwners { get; set; }
        public DbSet<Packer> Packers { get; set; }
        public DbSet<DestinationFloor> DestinationFloors { get; set; }

    }
}
