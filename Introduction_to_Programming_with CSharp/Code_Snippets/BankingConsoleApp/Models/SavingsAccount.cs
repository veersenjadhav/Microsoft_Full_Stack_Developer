namespace BankingConsoleApp.Models
{
    public class SavingsAccount : Account
    {
        public decimal InterestRate { get; set; }

        public SavingsAccount()
        {
            InterestRate = 4.5m;
        }

        public override void Deposit(decimal adecAmount)
        {
            if (adecAmount > 0)
            {
                Balance += adecAmount;
            }
        }

        public override void Withdraw(decimal adecAmount)
        {
            if (adecAmount > 0 && Balance > 0)
            {
                if ((Balance - adecAmount) >= 0)
                {
                    Balance -= adecAmount;
                }
            }
        }
    }
}