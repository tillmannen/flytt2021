using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace flytt2021.Data.Database;

public class ApplicationDbContext : IdentityDbContext<FlyttUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        SeedUsers(builder);
        SeedRoles(builder);
        SeedUserRoles(builder);
    }

    private void SeedUsers(ModelBuilder builder)
    {
        FlyttUser user = new FlyttUser()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Elin",
            Email = "elin.tillman@gmail.com",
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "1234567890",
            MoveId = 1
        };
        FlyttUser user2 = new FlyttUser()
        {
            Id = "c74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Axel",
            Email = "axel.tillman@gmail.com",
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "1234567890",
            MoveId = 1
        };
        FlyttUser user3 = new FlyttUser()
        {
            Id = "d74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Vera",
            Email = "tillman.vera@gmail.com",
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "1234567890",
            MoveId = 1
        };
        FlyttUser user4 = new FlyttUser()
        {
            Id = "e74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Olle",
            Email = "bror.olle.tillman@gmail.com",
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "1234567890",
            MoveId = 1
        };
        FlyttUser user5 = new FlyttUser()
        {
            Id = "f74ddd14-6340-4840-95c2-db12554843e5",
            UserName = "Fredrik",
            Email = "fredrik.tillman@gmail.com",
            LockoutEnabled = false,
            EmailConfirmed = true,
            PhoneNumber = "1234567890",
            MoveId = 1
        };

        PasswordHasher<FlyttUser> passwordHasher = new PasswordHasher<FlyttUser>();
        passwordHasher.HashPassword(user, "Flytt#21");
        passwordHasher.HashPassword(user2, "Flytt#21");
        passwordHasher.HashPassword(user3, "Flytt#21");
        passwordHasher.HashPassword(user4, "Flytt#21");
        passwordHasher.HashPassword(user5, "Flytt#21");

        builder.Entity<FlyttUser>().HasData(user,user2,user3,user4,user5);
    }

    private void SeedRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" }
            );
    }

    private void SeedUserRoles(ModelBuilder builder)
    {
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "f74ddd14-6340-4840-95c2-db12554843e5" }
            );
    }
}

public class FlyttUser : IdentityUser
{
    public int? MoveId { get; set; }
}
