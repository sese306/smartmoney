using System;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;

namespace SmartMoney
{
    public class AddAccountViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        public Account Account { get; set; }

        public Array AccountTypes { get; set; }

        public AddAccountViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Account = new Account();
            AccountTypes = Enum.GetValues(typeof(AccountType));
        }

        public void Save()
        {
            _eventAggregator.PublishOnUIThread(new ShowOverviewScreenMessage());
        }
    }
}