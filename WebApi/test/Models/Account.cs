using System;

namespace test.Models
{
    public class Account
    {
        public int Type { get; set; }
        public decimal Balance { get; set; }
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}