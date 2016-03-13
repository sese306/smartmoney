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
        private readonly SessionService _sessionService;
        public Account Account { get; set; }

        public Array AccountTypes { get; set; }

        public AddAccountViewModel(IEventAggregator eventAggregator, IAccountsApi accountsApi, SessionService sessionService)
        {
            _eventAggregator = eventAggregator;
            _accountsApi = accountsApi;
            _sessionService = sessionService;
            AccountTypes = Enum.GetValues(typeof(AccountType));
            Account = new Account();
        }

        public async Task Save()
        {
            Account.UserId = _sessionService.Currentuser.Id;
            await _accountsApi.CreateAccount(Account);
            _eventAggregator.PublishOnUIThread(new ShowOverviewScreenMessage());
        }
    }
}