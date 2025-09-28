namespace BankingConsoleApp
{
    public class Account
    {
        public long AccountNumber { get; set; }

        public long CustomerId { get; set; }

        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual void Deposit(decimal adecAmount)
        {

        }

        public virtual void Withdraw(decimal adecAmount)
        {
            
        }
    }
}