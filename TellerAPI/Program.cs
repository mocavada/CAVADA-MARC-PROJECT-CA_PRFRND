using System;
using System.IO;
using TellerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace TellerAPI
{
    class Program
    {
        static void Main()
        {
            Bank bank;

            try
            {
                // Build the EF Core context options
                var optionsBuilder = new DbContextOptionsBuilder<TellerDbContext>();
                optionsBuilder.UseSqlServer("Server=localhost,1433;Database=ATM;User Id=sa;Password=YourStrong!Pass123;TrustServerCertificate=True;");

                using var context = new TellerDbContext(optionsBuilder.Options);

                // Try connecting to the database
                if (context.Database.CanConnect())
                {
                    Console.WriteLine("✅ Connected to SQL Server.");
                    bank = new Bank(context);
                }
                else
                {
                    throw new Exception("Database connection failed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ SQL connection failed: {ex.Message}");
                Console.WriteLine("Switching to local text data...\n");

                string dataFolder = Path.Combine(AppContext.BaseDirectory, "Data");

                if (!Directory.Exists(dataFolder))
                {
                    Console.WriteLine($"❌ Data folder not found: {dataFolder}");
                    return;
                }

                var (accounts, customers) = Bank.LoadFromFiles(dataFolder);
                bank = new Bank(accounts, customers);
            }

            Console.WriteLine("\n🏦 Welcome to the Teller API\n");

            while (true)
            {
                Console.Write("Enter your account number: ");
                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("⚠️ Please enter a valid account number.\n");
                    continue;
                }

                // Use your Bank class to find the account
                var account = bank.FindAccount(input);

                if (account == null)
                {
                    Console.WriteLine("❌ Account not found. Try again.\n");
                    continue;
                }

                Console.WriteLine($"✅ Found Account:\n  Number: {account.AccountNumber}\n  Balance: {account.Balance:C}\n");
                break;
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}