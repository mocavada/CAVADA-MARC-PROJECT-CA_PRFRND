using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using TellerAPI.Models;
using TellerAPI.Services;   // <--- Add this

class Program
{
    static void Main()
    {
        Bank bank;

        try
        {
            var optionsBuilder = new DbContextOptionsBuilder<TellerDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ATM;User Id=sa;Password=YourStrong!Pass123;");
            using var context = new TellerDbContext(optionsBuilder.Options);

            if (context.Database.CanConnect())
            {
                Console.WriteLine("✅ Connected to SQL Server.");
                bank = new Bank(context);
            }
            else
            {
                Console.WriteLine("⚠️ SQL Server is not reachable. Using local text data...");
                LoadLocalData(out bank);
            }
        }
        catch (Exception ex)  // catch general exceptions from EF/SQL
        {
            Console.WriteLine($"⚠️ SQL connection failed: {ex.Message}");
            LoadLocalData(out bank);
        }

        // Start ATM
        var atm = new ATMService(bank);
        atm.Start();
    }

    static void LoadLocalData(out Bank bank)
    {
        string dataFolder = Path.Combine(AppContext.BaseDirectory, "Data");
        var (accounts, customers) = Bank.LoadFromFiles(dataFolder);
        bank = new Bank(accounts, customers);
        Console.WriteLine($"\n🏦 Loaded {accounts.Count} accounts from local text data.");
    }
}
