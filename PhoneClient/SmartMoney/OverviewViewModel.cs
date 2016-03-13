using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;
using SmartMoney.SmartmoneyAPI;

namespace SmartMoney
{
    public class OverviewViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IAccountsApi _accountsApi;
        private readonly SessionService _sessionService;
        private List<Account> _accounts;

        public List<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                if (Equals(value, _accounts)) return;
                _accounts = value;
                NotifyOfPropertyChange();
            }
        }

        public OverviewViewModel(IEventAggregator eventAggregator, IAccountsApi accountsApi,
            SessionService sessionService)
        {
            _eventAggregator = eventAggregator;
            _accountsApi = accountsApi;
            _sessionService = sessionService;
            Accounts = new List<Account>
            {
                new Account {Name = "test1", Balance = 12.12m},
                new Account {Name = "test1", Balance = 12.12m}
            };
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            Accounts = (await _accountsApi.GetAllAccounts(_sessionService.Currentuser.Id)).ToList();
        }

        public void AddAccount()
        {
            _eventAggregator.PublishOnUIThread(new ShowAddAccountMessage());
        }

        public void ShowDetails(Account account)
        {
            _eventAggregator.PublishOnUIThread(new ShowAccountDetailsMessage(account));
        }
    }
}