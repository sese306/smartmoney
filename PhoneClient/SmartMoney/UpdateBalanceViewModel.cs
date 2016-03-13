using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Caliburn.Micro;
using SmartMoney.Models;
using SmartMoney.SmartmoneyAPI;

namespace SmartMoney
{
    public class UpdateBalanceViewModel : Screen
    {
        private readonly IEstimationsApi _estimationsApi;
        private readonly SessionService _sessionService;
        private readonly ITransactionsApi _transactionsApi;
        private List<Estimation> _estimations;

        public List<Estimation> Estimations
        {
            get { return _estimations; }
            set
            {
                if (Equals(value, _estimations)) return;
                _estimations = value;
                NotifyOfPropertyChange();
            }
        }

        public UpdateBalanceViewModel(IEstimationsApi estimationsApi, SessionService sessionService,
            ITransactionsApi transactionsApi)
        {
            _estimationsApi = estimationsApi;
            _sessionService = sessionService;
            _transactionsApi = transactionsApi;
        }

        protected override async void OnActivate()
        {
            base.OnActivate();
            Estimations = (await _estimationsApi.GetAll(_sessionService.Currentuser.Id)).ToList();
        }

        public async Task SaveEstimations()
        {
            foreach (var estimation in Estimations)
            {
                var transaction = new Transaction(estimation) {AccountId = _sessionService.CurrentAccountId};
                await _transactionsApi.CreateTransaction(transaction);
            }
        }
    }
}