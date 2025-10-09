namespace BankingConsoleApp.Models
{
    public abstract class Account
    {
        public long AccountNumber { get; set; }

        public long CustomerId { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public abstract void Deposit(decimal adecAmount);

        public abstract void Withdraw(decimal adecAmount);
    }
}