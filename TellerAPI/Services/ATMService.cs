using System;
using TellerAPI.Models;

namespace TellerAPI.Services
{
    public class ATMService
    {
        private readonly Bank _bank;
        private Account? _currentAccount;

        public ATMService(Bank bank) => _bank = bank;

        public void Start()
        {
            // Login / select account
            while (_currentAccount == null)
            {
                Console.Write("Enter your account number: ");
                string? accNumber = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(accNumber))
                {
                    Console.WriteLine("❌ Please enter a valid account number.");
                    continue;
                }

                _currentAccount = _bank.FindAccount(accNumber);

                if (_currentAccount == null)
                    Console.WriteLine("❌ Account not found. Try again.");
            }

            Console.WriteLine($"\n✅ Logged in as {_currentAccount.CustomerID}!");

            // Main transaction loop
            while (true)
            {
                Console.WriteLine("\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Exit");
                Console.Write("Select an option: ");
                string? input = Console.ReadLine()?.Trim();

                switch (input)
                {
                    case "1":
                        HandleDeposit();
                        break;
                    case "2":
                        HandleWithdrawal();
                        break;
                    case "3":
                        ShowBalance();
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
            if (_currentAccount == null) return;

            Console.Write("Enter deposit amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                try
                {
                    _currentAccount.Deposit(amount);
                    Console.WriteLine($"✅ Deposit successful. New Balance: {_currentAccount.Balance:C}");
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
            if (_currentAccount == null) return;

            Console.Write("Enter withdrawal amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                try
                {
                    if (_currentAccount.Withdraw(amount))
                        Console.WriteLine($"✅ Withdrawal successful. New Balance: {_currentAccount.Balance:C}");
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

        private void ShowBalance()
        {
            if (_currentAccount == null) return;
            Console.WriteLine($"💰 Current Balance: {_currentAccount.Balance:C}");
        }
    }
}
