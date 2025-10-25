using System;
using System.Collections.Generic;
using TellerAPI.Services;

namespace TellerAPI.Models
{
    public class Bank
    {
        private readonly FileService _fileService;
        public List<Account> Accounts { get; private set; } = new();

        public Bank()
        {
            _fileService = new FileService();
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            var lines = _fileService.ReadFile("Accounts.txt");

            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length < 4) continue;

                string type = parts[0].Trim();           // "C" or "S"
                string customerId = parts[1].Trim();     // e.g., "D001"
                string accountNumber = parts[2].Trim();  // e.g., "10001"
                if (!decimal.TryParse(parts[3], out decimal balance))
                    balance = 0;

                Account? account = type switch
                {
                    "C" => new CheckingAccount { CustomerID = customerId, AccountNumber = accountNumber },
                    "S" => new SavingAccount { CustomerID = customerId, AccountNumber = accountNumber },
                    _ => null
                };

                if (account != null)
                {
                    if (balance > 0)
                        account.Deposit(balance); // use Deposit to set initial balance safely
                    Accounts.Add(account);
                }
            }
        }

        // Helper method to find an account by account number
        public Account? GetAccount(string accountNumber)
        {
            return Accounts.Find(a => a.AccountNumber == accountNumber);
        }

        // Optional helper to find accounts by CustomerID
        public List<Account> GetAccountsByCustomer(string customerId)
        {
            return Accounts.FindAll(a => a.CustomerID == customerId);
        }
    }
}
