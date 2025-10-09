namespace BankingConsoleApp.Models
{
    public class CurrentAccount : Account
    {
        public decimal OverDraftLimit { get; set; }

        public CurrentAccount()
        {
            OverDraftLimit = 20000.00m;
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
            if (adecAmount > 0 && Balance > (-1 * OverDraftLimit))
            {
                if ((Balance - adecAmount) > (-1 * OverDraftLimit))
                {
                    Balance -= adecAmount;
                }
            }
        }
    }
}