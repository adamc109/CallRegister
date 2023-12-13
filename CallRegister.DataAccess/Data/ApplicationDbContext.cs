﻿using CallRegister.Models;
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
        public DbSet<Teams> Teams { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>().HasData(
                new Agent { Id = 1, Name = "Nick", TeamId = 1 },
                new Agent { Id = 2, Name = "Mark", TeamId = 2 },
                new Agent { Id = 3, Name = "David", TeamId = 3 },
                new Agent { Id = 4, Name = "Dean", TeamId = 3 },
                new Agent { Id = 5, Name = "Kenny", TeamId = 4 }
                );

            modelBuilder.Entity<Products>().HasData(
                new Products { Id = 1, Name = "Actuators" },
                new Products { Id = 2, Name = "Eletric Drives" },
                new Products { Id = 3, Name = "Chillers" },
                new Products { Id = 4, Name = "Air Prep" },
                new Products { Id = 5, Name = "Valves" }
                );

            modelBuilder.Entity<Teams>().HasData(
                new Teams { Id = 1, Name = "Distribution" },
                new Teams { Id = 2, Name = "Actuators" },
                new Teams { Id = 3, Name = "Air and Fluid" },
                new Teams { Id = 4, Name = "Electrical" }
                );
        }
    }


}
