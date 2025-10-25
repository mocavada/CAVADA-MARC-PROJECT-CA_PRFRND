namespace InventoryAPI
{
    public class Item
    {
        public int Id { get; set; }  // Primary key
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}