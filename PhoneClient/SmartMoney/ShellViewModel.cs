using System;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;

namespace SmartMoney
{
    public class ShellViewModel : Conductor<Screen>, IHandle<ShowAddAccountMessage>, 
        IHandle<ShowOverviewScreenMessage>, IHandle<ShowAccountDetailsMessage>
    {
        private readonly WelcomeScreenViewModel _welcomeScreenViewModel;
        private readonly AddAccountViewModel _addAccountViewModel;
        private readonly OverviewViewModel _overviewViewModel;
        private readonly AccountDetailsViewModel _accountDetailsViewModel;

        public ShellViewModel(
            WelcomeScreenViewModel welcomeScreenViewModel, 
            AddAccountViewModel addAccountViewModel,
            OverviewViewModel overviewViewModel,
            AccountDetailsViewModel accountDetailsViewModel,
            IEventAggregator eventAggregator)
        {
            _welcomeScreenViewModel = welcomeScreenViewModel;
            _addAccountViewModel = addAccountViewModel;
            _overviewViewModel = overviewViewModel;
            _accountDetailsViewModel = accountDetailsViewModel;
            eventAggregator.Subscribe(this);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
            if (GetCurrentUser() != null)
            {
                throw new NotImplementedException();
            }

            ActivateItem(_welcomeScreenViewModel);
        }

        private static User GetCurrentUser()
        {
            return null;
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