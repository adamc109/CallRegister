using CallRegisterWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CallRegisterWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<Agent> Agents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasData(
                new Agent { Id = 1, Name = "Nick", Team= "Distribution" },
                new Agent { Id = 2, Name = "Mark", Team = "Distribution" },
                new Agent { Id = 3, Name = "David", Team = "Actuator" },
                new Agent { Id = 4, Name = "Dean", Team = "Air and Fluid" },
                new Agent { Id = 5, Name = "Kenny", Team = "Electrical" }
                );
        }
    }


}
