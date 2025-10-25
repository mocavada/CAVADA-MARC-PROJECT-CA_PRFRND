using Microsoft.EntityFrameworkCore;

namespace TellerAPI.Models
{
    public class TellerDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;

        public TellerDbContext(DbContextOptions<TellerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountNumber);

            // Map inheritance
            modelBuilder.Entity<CheckingAccount>().HasBaseType<Account>();
            modelBuilder.Entity<SavingsAccount>().HasBaseType<Account>();

            // Relationships
            modelBuilder.Entity<Account>()
                .HasOne(a => a.Customer)
                .WithMany()
                .HasForeignKey(a => a.CustomerID);
        }
    }
}