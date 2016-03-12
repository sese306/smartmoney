using System;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;

namespace SmartMoney
{
    public class ShellViewModel : Conductor<Screen>.Collection.OneActive, IHandle<ShowAddAccountMessage>
    {
        private readonly WelcomeScreenViewModel _welcomeScreenViewModel;
        private readonly AddAccountViewModel _addAccountViewModel;

        public ShellViewModel(
            WelcomeScreenViewModel welcomeScreenViewModel, 
            AddAccountViewModel addAccountViewModel,
            IEventAggregator eventAggregator)
        {
            _welcomeScreenViewModel = welcomeScreenViewModel;
            _addAccountViewModel = addAccountViewModel;
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
    }
}