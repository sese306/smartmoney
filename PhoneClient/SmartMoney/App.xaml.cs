using System;
using System.Collections.Generic;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Caliburn.Micro;
using Refit;
using SmartMoney.SmartmoneyAPI;

namespace SmartMoney
{
    public sealed partial class App
    {
        private WinRTContainer _container;
        private IUsersApi _usersApi;
        private ITransactionsApi _transactionsApi;
        private IStopsApi _stopsApi;
        private IAccountsApi _accountsApi;
        private IEstimationsApi _estimationsApi;

        public App()
        {
            InitializeComponent();
        }

        protected override void Configure()
        {
            _container = new WinRTContainer();
            _container.RegisterWinRTServices();

            _container.PerRequest<ShellViewModel>();
            _container.PerRequest<AddAccountViewModel>();
            _container.PerRequest<WelcomeScreenViewModel>();
            _container.PerRequest<OverviewViewModel>();
            _container.PerRequest<AccountDetailsViewModel>();
            _container.PerRequest<UpdateBalanceViewModel>();
            _container.Singleton<SessionService>();
            _container.RegisterHandler(typeof (IUsersApi), "UsersApi",
                container => _usersApi ?? (_usersApi = RestService.For<IUsersApi>("http://localhost:60113/")));
            _container.RegisterHandler(typeof(ITransactionsApi), "TransactionsApi",
                container => _transactionsApi ?? (_transactionsApi = RestService.For<ITransactionsApi>("http://localhost:60113/")));
            _container.RegisterHandler(typeof(IStopsApi), "StopsApi",
                container => _stopsApi ?? (_stopsApi = RestService.For<IStopsApi>("http://localhost:60113/")));
            _container.RegisterHandler(typeof(IAccountsApi), "AccountsApi",
                container => _accountsApi ?? (_accountsApi = RestService.For<IAccountsApi>("http://localhost:60113/")));
            _container.RegisterHandler(typeof(IEstimationsApi), "EstimationsApi",
                container => _estimationsApi ?? (_estimationsApi = RestService.For<IEstimationsApi>("http://localhost:60113/")));
        }

        protected override object GetInstance(Type service, string key)
        {
            var instance = _container.GetInstance(service, key);
            if (instance != null)
                return instance;
            throw new Exception("Could not locate any instances.");
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (args.PreviousExecutionState == ApplicationExecutionState.Running)
                return;

            DisplayRootViewFor<ShellViewModel>();
        }

        protected override void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}