using Microsoft.EntityFrameworkCore;

namespace TellerAPI.Models
{
    public class TellerDbContext : DbContext
    {
        public TellerDbContext(DbContextOptions<TellerDbContext> options) : base(options) { }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TPH mapping for Account hierarchy
            modelBuilder.Entity<Account>()
                .ToTable("Accounts")
                .HasDiscriminator<string>("Discriminator")
                .HasValue<CheckingAccount>("C")
                .HasValue<SavingsAccount>("S");

            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber);

            modelBuilder.Entity<Customer>()
                .HasKey(c => c.CustomerID);
        }
    }
}