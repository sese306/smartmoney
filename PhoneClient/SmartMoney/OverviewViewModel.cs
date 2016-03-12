using System.Collections.Generic;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;

namespace SmartMoney
{
    public class OverviewViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public List<Account> Accounts { get; set; }

        public OverviewViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            Accounts = new List<Account>
            {
                new Account { Name = "test1", Balance = 12.12m },
                new Account { Name = "test1", Balance = 12.12m }
            };
        }

        public void AddAccount()
        {
            _eventAggregator.PublishOnUIThread(new ShowAddAccountMessage());
        }

        public void ShowDetails(Account account)
        {
        }
    }
}