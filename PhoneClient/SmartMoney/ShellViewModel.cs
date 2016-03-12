using System;
using System.Threading.Tasks;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;
using SmartMoney.SmartmoneyAPI;

namespace SmartMoney
{
    public class ShellViewModel : Conductor<Screen>, IHandle<ShowAddAccountMessage>, 
        IHandle<ShowOverviewScreenMessage>, IHandle<ShowAccountDetailsMessage>
    {
        private readonly WelcomeScreenViewModel _welcomeScreenViewModel;
        private readonly AddAccountViewModel _addAccountViewModel;
        private readonly OverviewViewModel _overviewViewModel;
        private readonly AccountDetailsViewModel _accountDetailsViewModel;
        private readonly IUsersApi _usersApi;

        public User CurrentUser { get; set; }

        public ShellViewModel(
            WelcomeScreenViewModel welcomeScreenViewModel, 
            AddAccountViewModel addAccountViewModel,
            OverviewViewModel overviewViewModel,
            AccountDetailsViewModel accountDetailsViewModel,
            IUsersApi usersApi,
            IEventAggregator eventAggregator)
        {
            _welcomeScreenViewModel = welcomeScreenViewModel;
            _addAccountViewModel = addAccountViewModel;
            _overviewViewModel = overviewViewModel;
            _accountDetailsViewModel = accountDetailsViewModel;
            _usersApi = usersApi;
            eventAggregator.Subscribe(this);
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            CurrentUser = await GetSavedUser();
            if (CurrentUser != null)
            {
                ActivateItem(_overviewViewModel);
            }
            else
            {
                CurrentUser = await CreateUser();
                ActivateItem(_welcomeScreenViewModel);
            }
        }

        private Task<User> CreateUser()
        {
            return _usersApi.Createuser(new User {Email = "some@email.com"});
        }

        private static Task<User> GetSavedUser()
        {
            return Task.Run(() => (User) null);
        }

        public void Handle(ShowAddAccountMessage message)
        {
            ActivateItem(_addAccountViewModel);
        }

        public void Handle(ShowOverviewScreenMessage message)
        {
            ActivateItem(_overviewViewModel);
        }

        public void Handle(ShowAccountDetailsMessage message)
        {
            _accountDetailsViewModel.Account = message.Account;
            ActivateItem(_accountDetailsViewModel);
        }
    }
}