using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SberTaskDLA.Models;

namespace SberTaskDLA
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // seeding roles
            builder.Entity<IdentityRole>().HasData
                (
                    new IdentityRole() { Name = "Admin" },
                    new IdentityRole() { Name = "User" }
                );

            var user = new ApplicationUser()
            {
                FirstName = "Anuar",
                MiddleName = "Borangaziyev",
                LastName = "Farkhatuly",
                PhoneNumber = "87775554466",
                Email = "anuar@mail.ru",

            };
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            passwordHasher.HashPassword(user, "Admin*123");
            builder.Entity<ApplicationUser>().HasData(user);
            
        }
    }
}