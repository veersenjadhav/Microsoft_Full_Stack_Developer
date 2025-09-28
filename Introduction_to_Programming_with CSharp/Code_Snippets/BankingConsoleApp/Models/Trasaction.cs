namespace BankingConsoleApp
{
    public class Transaction
    {
        public decimal Balance { get; set; }

        public long AccountNumber { get; set; }

        public string? TxnType { get; set; }

        public decimal Amount { get; set; }

        public DateTime DateAndTime { get; set; }

        public string? Narration { get; set; }
    }
}