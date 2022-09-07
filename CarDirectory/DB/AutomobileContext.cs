using Microsoft.EntityFrameworkCore;
using CarDirectory.Models;

namespace CarDirectory.DB
{
    public class AutomobileContext:DbContext
    {
        private readonly DbSet<Automobile> Automobiles;
        public AutomobileContext(DbContextOptions<AutomobileContext> options) :base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automobile>();
        }
    }
}
