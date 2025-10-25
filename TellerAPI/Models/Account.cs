namespace TellerAPI.Models
{
    public abstract class Account
    {
        public string AccountNumber { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public decimal Balance { get; protected set; }

        // Optional constructor for initial deposit
        protected Account(decimal initialBalance = 0)
        {
            if (initialBalance > 0)
                Deposit(initialBalance);
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");
            Balance += amount;
        }

        public virtual bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");
            if (Balance < amount)
                return false;

            Balance -= amount;
            return true;
        }

        public override string ToString() =>
            $"{AccountNumber} | {CustomerName} | Balance: {Balance:C}";
    }
}
