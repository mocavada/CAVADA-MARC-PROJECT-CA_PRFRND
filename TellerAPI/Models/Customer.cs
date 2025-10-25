namespace TellerAPI.Models
{
    public class Customer
    {
        public string CustomerID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public List<Account> Accounts { get; set; } = new();
    }
}