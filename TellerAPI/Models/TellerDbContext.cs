using Microsoft.EntityFrameworkCore;
using TellerAPI.Models;

namespace TellerAPI
{
    public class TellerDbContext : DbContext
    {
        public TellerDbContext(DbContextOptions<TellerDbContext> options)
            : base(options)
        {
        }

        // Default parameterless constructor (for fallback use)
        public TellerDbContext()
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only configure if not already done externally
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ATM;User Id=sa;Password=YourStrong!Pass123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // EF Core requires specifying derived types for abstract base classes
            modelBuilder.Entity<SavingsAccount>().HasBaseType<Account>();
        }
    }
}