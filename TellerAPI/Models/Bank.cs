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

                string type = parts[0].Trim();
                string number = parts[1].Trim();
                string name = parts[2].Trim();
                if (!decimal.TryParse(parts[3], out decimal balance))
                    balance = 0;

                Account? account = type switch
                {
                    "Checking" => new CheckingAccount { AccountNumber = number, CustomerName = name },
                    "Saving" => new SavingAccount { AccountNumber = number, CustomerName = name },
                    _ => null
                };

                if (account != null)
                {
                    if (balance > 0)
                        account.Deposit(balance); // <-- use Deposit method instead of setting Balance
                    Accounts.Add(account);
                }
            }
        }

        // Optional: helper to find account by number
        public Account? GetAccount(string accountNumber)
        {
            return Accounts.Find(a => a.AccountNumber == accountNumber);
        }
    }
}

