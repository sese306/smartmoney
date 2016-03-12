using Caliburn.Micro;
using SmartMoney.Messages;

namespace SmartMoney
{
    public class WelcomeScreenViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;

        public WelcomeScreenViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        public void AddAccount()
        {
            _eventAggregator.PublishOnUIThread(new ShowAddAccountMessage());
        }
    }
}