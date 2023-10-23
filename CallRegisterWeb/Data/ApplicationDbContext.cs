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
    }
}
