namespace SmartMoney.Models
{
    public class Account
    {
        public string Name { get; set; }

        public AccountType Type { get; set; }

        public decimal Balance { get; set; }
    }
}