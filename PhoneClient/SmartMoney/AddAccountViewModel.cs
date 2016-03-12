using System;
using Caliburn.Micro;
using SmartMoney.Models;

namespace SmartMoney
{
    public class AddAccountViewModel : Screen
    {
        public Account Account { get; set; }

        public Array AccountTypes { get; set; }

        public AddAccountViewModel()
        {
            Account = new Account();
            AccountTypes = Enum.GetValues(typeof(AccountType));
        }

        public void Save()
        {
        }
    }
}