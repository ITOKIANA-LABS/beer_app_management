using beer_app_management.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
        {
            
        }

        public DbSet<Beer> Beer { get; set; }
        public DbSet<WSStock> WSStock { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole
                {
                    Name = "Brewer",
                    NormalizedName = "BREWER",
                },
                new IdentityRole
                {
                    Name = "Wholesaler",
                    NormalizedName = "WHOLESALER",
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}