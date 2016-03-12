using System;

namespace SmartMoney.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public User()
        {
            Id = Guid.NewGuid();
        }
    }
}