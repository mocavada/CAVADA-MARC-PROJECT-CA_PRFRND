using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TellerAPI.Models
{
    public class TellerDbContextFactory : IDesignTimeDbContextFactory<TellerDbContext>
    {
        public TellerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TellerDbContext>();
            optionsBuilder.UseSqlServer(
                "Server=localhost,1433;Database=ATM;User Id=sa;Password=YourStrong!Pass123;TrustServerCertificate=True"
            );

            return new TellerDbContext(optionsBuilder.Options);
        }
    }
}