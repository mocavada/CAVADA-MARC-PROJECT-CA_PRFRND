using System;

namespace TellerAPI.Models
{
    public class SavingAccount : Account
    {
        public const decimal InterestRate = 0.01m; // 1%

        public void PayInterest()
        {
            if (Balance > 0)
            {
                decimal interest = Balance * InterestRate;
                Deposit(interest);
            }
        }
    }
}

