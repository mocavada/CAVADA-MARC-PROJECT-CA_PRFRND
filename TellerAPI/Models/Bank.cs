using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TellerAPI.Models
{
    public class Bank
    {
        private readonly TellerDbContext? _context;
        public List<Account> Accounts { get; private set; } = new();
        public List<Customer> Customers { get; private set; } = new();

        public Bank(TellerDbContext context)
        {
            _context = context;
            LoadAccounts();
        }

        // Fallback constructor when using text files
        public Bank(List<Account> accounts, List<Customer> customers)
        {
            Accounts = accounts;
            Customers = customers;
        }

        private void LoadAccounts()
        {
            if (_context != null)
            {
                Accounts = _context.Accounts.ToList();
                Customers = _context.Customers.ToList();
            }
        }

        public Account? FindAccount(string accountNumber)
        {
            return Accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        public static (List<Account> Accounts, List<Customer> Customers) LoadFromFiles(string dataFolder)
        {
            var accounts = new List<Account>();
            var customers = new List<Customer>();

            string accountsFile = Path.Combine(dataFolder, "Accounts.txt");
            string customersFile = Path.Combine(dataFolder, "Customer.txt");

            if (File.Exists(customersFile))
            {
                foreach (var line in File.ReadAllLines(customersFile))
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 2)
                    {
                        customers.Add(new Customer
                        {
                            Name = parts[0],
                            CustomerID = parts[1]
                        });
                    }
                }
            }

            if (File.Exists(accountsFile))
            {
                foreach (var line in File.ReadAllLines(accountsFile))
                {
                    var parts = line.Split(',');
                    if (parts.Length >= 4 && decimal.TryParse(parts[3], out decimal balance))
                    {
                        accounts.Add(new SavingsAccount
                        {
                            CustomerID = parts[1],
                            AccountNumber = parts[2],
                            Balance = balance
                        });
                    }
                }
            }

            return (accounts, customers);
        }
    }
}