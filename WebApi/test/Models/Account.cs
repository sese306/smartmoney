using System;

namespace test.Models
{
    public class Account
    {
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AccountType Type { get; set; }
        public Account ()
        {
            Id = Guid.NewGuid();
        }
    }
}