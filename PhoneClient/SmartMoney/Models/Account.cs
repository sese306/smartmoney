using System;

namespace SmartMoney.Models
{
    public class Account
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public AccountType Type { get; set; }

        public decimal Balance { get; set; }
        
        public Guid UserId { get; set; }

        public Account()
        {
            Id = Guid.NewGuid();
        }
    }
}