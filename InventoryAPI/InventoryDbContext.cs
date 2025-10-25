using Microsoft.EntityFrameworkCore;


namespace InventoryAPI
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
            : base(options) { }

        public DbSet<Item> Items { get; set; } = null!;
    }
}