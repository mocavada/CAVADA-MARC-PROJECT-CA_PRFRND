using System;

namespace TellerAPI.Models
{
    public class CheckingAccount : Account
    {
        public decimal MaximumBillAmount { get; set; } = 10000m;
        public const decimal BillFee = 1.25m;

        // Withdraw already handled in base class
        // Deposit already handled in base class

        // Pay bill method
        public bool PayBill(decimal amount)
        {
            if (amount <= 0) throw new ArgumentException("Amount must be positive.");
            if (amount + BillFee > Balance) return false;
            if (amount > MaximumBillAmount) return false;

            // Deduct amount + fee
            Withdraw(amount + BillFee);
            return true;
        }
    }
}

