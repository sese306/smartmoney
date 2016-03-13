using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;
using SmartMoney.SmartmoneyAPI;

namespace SmartMoney
{
    public class AccountDetailsViewModel : Screen
    {
        private readonly ITransactionsApi _transactionsApi;
        private readonly IEventAggregator _eventAggregator;
        private List<Transaction> _transactions;
        private Account _account;

        public Account Account
        {
            get { return _account; }
            set
            {
                if (Equals(value, _account)) return;
                _account = value;
                NotifyOfPropertyChange();
            }
        }

        public List<Transaction> Transactions
        {
            get { return _transactions; }
            set
            {
                if (Equals(value, _transactions)) return;
                _transactions = value;
                NotifyOfPropertyChange();
            }
        }

        public AccountDetailsViewModel(ITransactionsApi transactionsApi, IEventAggregator eventAggregator)
        {
            _transactionsApi = transactionsApi;
            _eventAggregator = eventAggregator;
        }

        public void UpdateBalance()
        {
            _eventAggregator.PublishOnUIThread(new ShowUpdateBalanceMessage { AccountId = Account.Id});
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            Transactions = (await _transactionsApi.Get(Account.Id)).ToList();
        }
    }
}