using CallRegister.Models;
using Microsoft.EntityFrameworkCore;

namespace CallRegisterWeb.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Email> Emails { get; set; }
        public DbSet<PhoneCall> PhoneCalls { get; set; }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<Products> Products { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasData(
                new Agent { Id = 1, Name = "Nick", Team= "Distribution" },
                new Agent { Id = 2, Name = "Mark", Team = "Distribution" },
                new Agent { Id = 3, Name = "David", Team = "Actuator" },
                new Agent { Id = 4, Name = "Dean", Team = "Air and Fluid" },
                new Agent { Id = 5, Name = "Kenny", Team = "Electrical" }
                );

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Actuators" },
                new Products { Id = 2, Name = "Eletric Drives" },
                new Products { Id = 3, Name = "Chillers" },
                new Products { Id = 4, Name = "Air Prep" },
                new Products { Id = 5, Name = "Valves" }

                );
        }
    }


}
