using System;
using SmartMoney.Models;

namespace SmartMoney
{
    public class SessionService
    {
        public User Currentuser { get; set; }
        public Guid CurrentAccountId { get; set; }
    }
}