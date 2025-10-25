using System;
using TellerAPI.Models;

namespace TellerAPI.Services
{
    public class ATMService
    {
        private readonly Bank _bank;
        private Account _currentAccount = null!; // non-nullable after login

        public ATMService(Bank bank)
        {
            _bank = bank;
        }

        public void Start()
        {
            Console.WriteLine("🏦 Welcome to the Teller API");

            // Login / select account
            while (true)
            {
                Console.Write("\nEnter your account number: ");
                string? accNumber = Console.ReadLine();

                var account = _bank.Accounts.Find(a => a.AccountNumber == accNumber);

                if (account != null)
                {
                    _currentAccount = account;
                    break;
                }

                Console.WriteLine("❌ Account not found. Try again.");
            }

            Console.WriteLine($"\n✅ Logged in as {_currentAccount.CustomerID}!");

            // Main transaction loop
            while (true)
            {
                Console.WriteLine("\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
                Console.Write("\nSelect an option: ");
                string? input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        HandleDeposit();
                        break;

                    case "2":
                        HandleWithdrawal();
                        break;

                    case "3":
                        Console.WriteLine($"💰 Current Balance: {_currentAccount.Balance:C}");
                        break;

                    case "4":
                        Console.WriteLine("👋 Thank you for using TellerAPI!");
                        return;

                    default:
                        Console.WriteLine("❌ Invalid option. Try again.");
                        break;
                }
            }
        }

        private void HandleDeposit()
        {
            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                try
                {
                    _currentAccount.Deposit(amount);
                    Console.WriteLine($"✅ New Balance: {_currentAccount.Balance:C}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"❌ {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid amount entered.");
            }
        }

        private void HandleWithdrawal()
        {
            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                try
                {
                    if (_currentAccount.Withdraw(amount))
                        Console.WriteLine($"✅ New Balance: {_currentAccount.Balance:C}");
                    else
                        Console.WriteLine("❌ Insufficient funds!");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"❌ {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("❌ Invalid amount entered.");
            }
        }
    }
}
