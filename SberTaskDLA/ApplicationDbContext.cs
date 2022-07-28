using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SberTaskDLA.Models;

namespace SberTaskDLA
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //// seeding roles
            //builder.Entity<IdentityRole>().HasData
            //    (
            //        new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", NormalizedName = "ADMIN",ConcurrencyStamp = "1" },
            //        new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "User", NormalizedName = "USER", ConcurrencyStamp = "2" }
            //    );

            //string userGuid = Guid.NewGuid().ToString();
            //var user = new ApplicationUser()
            //{
            //    Id = userGuid,
            //    FirstName = "Anuar",
            //    MiddleName = "Borangaziyev",
            //    LastName = "Farkhatuly",
            //    PhoneNumber = "87775554466",
            //    Email = "anuar@mail.ru",
            //    SecurityStamp = Guid.NewGuid().ToString()

            //};
            //PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            //user.PasswordHash = passwordHasher.HashPassword(user, "Admin*123");
            //builder.Entity<ApplicationUser>().HasData(user);
            //builder.Entity<IdentityUserRole<string>>().HasData
            //    (
            //        new IdentityUserRole<string>()
            //        {
            //            RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", 
            //            UserId = userGuid
            //        }
            //    );
            
        }
    }
}