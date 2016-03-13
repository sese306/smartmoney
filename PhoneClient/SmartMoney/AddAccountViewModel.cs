using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;
using SmartMoney.SmartmoneyAPI;

namespace SmartMoney
{
    public class AddAccountViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IAccountsApi _accountsApi;
        public Account Account { get; set; }

        public Array AccountTypes { get; set; }

        public AddAccountViewModel(IEventAggregator eventAggregator, IAccountsApi accountsApi)
        {
            _eventAggregator = eventAggregator;
            _accountsApi = accountsApi;
            Account = new Account();
            AccountTypes = Enum.GetValues(typeof(AccountType));
        }

        public async Task Save()
        {
            await _accountsApi.CreateAccount(Account);
            _eventAggregator.PublishOnUIThread(new ShowOverviewScreenMessage());
        }
    }
}