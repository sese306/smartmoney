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
        private const string UserIdKey = "UserId";
        private readonly WelcomeScreenViewModel _welcomeScreenViewModel;
        private readonly AddAccountViewModel _addAccountViewModel;
        private readonly OverviewViewModel _overviewViewModel;
        private readonly AccountDetailsViewModel _accountDetailsViewModel;
        private readonly IUsersApi _usersApi;
        private readonly SessionService _sessionService;

        public ShellViewModel(
            WelcomeScreenViewModel welcomeScreenViewModel, 
            AddAccountViewModel addAccountViewModel,
            OverviewViewModel overviewViewModel,
            AccountDetailsViewModel accountDetailsViewModel,
            IUsersApi usersApi,
            SessionService sessionService,
            IEventAggregator eventAggregator)
        {
            _welcomeScreenViewModel = welcomeScreenViewModel;
            _addAccountViewModel = addAccountViewModel;
            _overviewViewModel = overviewViewModel;
            _accountDetailsViewModel = accountDetailsViewModel;
            _usersApi = usersApi;
            _sessionService = sessionService;
            eventAggregator.Subscribe(this);
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            _sessionService.Currentuser = await GetSavedUser();
            if (_sessionService.Currentuser != null)
            {
                ActivateItem(_overviewViewModel);
            }
            else
            {
                _sessionService.Currentuser = await CreateUser();
                SaveCurrentUser(_sessionService.Currentuser);
                ActivateItem(_welcomeScreenViewModel);
            }
        }

        private static void SaveCurrentUser(User currentUser)
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values[UserIdKey] = currentUser.Id.ToString();
        }

        private static Task<User> GetSavedUser()
        {
            var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            User user = null;
            if (localSettings.Values.ContainsKey(UserIdKey))
            {
                user = new User { Id = Guid.Parse(localSettings.Values[UserIdKey].ToString())};
            }

            return Task.Run(() => user);
        }

        private Task<User> CreateUser()
        {
            return _usersApi.CreateUser(new User {Email = "some@email.com"});
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