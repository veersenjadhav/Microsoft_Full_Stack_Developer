namespace BankingConsoleApp
{
    public class Customer
    {
        public long CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        public void AddCustomerDetails(string? lstrName, string? lstrEmail, string? lstrPhone)
        {
            Name = lstrName;
            Email = lstrEmail;
            Phone = lstrPhone;

            CustomerId = DateTime.UtcNow.Ticks;
        }
    }
}