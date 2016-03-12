using System;
using Caliburn.Micro;
using SmartMoney.Messages;
using SmartMoney.Models;

namespace SmartMoney
{
    public class ShellViewModel : Conductor<Screen>, IHandle<ShowAddAccountMessage>, 
        IHandle<ShowOverviewScreenMessage>
    {
        private readonly WelcomeScreenViewModel _welcomeScreenViewModel;
        private readonly AddAccountViewModel _addAccountViewModel;
        private readonly OverviewViewModel _overviewViewModel;

        public ShellViewModel(
            WelcomeScreenViewModel welcomeScreenViewModel, 
            AddAccountViewModel addAccountViewModel,
            OverviewViewModel overviewViewModel,            
            IEventAggregator eventAggregator)
        {
            _welcomeScreenViewModel = welcomeScreenViewModel;
            _addAccountViewModel = addAccountViewModel;
            _overviewViewModel = overviewViewModel;
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
    }
}