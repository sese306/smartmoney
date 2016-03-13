using System.Linq;
using SmartMoneyJobRunner.Models;

namespace SmartMoneyJobRunner
{
    public class EstimateExpenses
    {
        private const int SameLocationRadios = 5;
        private readonly SmartMoneyDbContext _smartMoneyDbContext;

        public EstimateExpenses()
        {
            _smartMoneyDbContext = new SmartMoneyDbContext();
        }

        public void Run()
        {
            var nonEstimatedStops =
                _smartMoneyDbContext.Stops.Where(
                    stop => _smartMoneyDbContext.Transactions.Count(transaction => transaction.StopId == stop.Id) == 0)
                    .ToList();
            foreach (var stop in nonEstimatedStops)
            {
                var estimation = CreateEstimation(stop);
                _smartMoneyDbContext.Estimations.Add(estimation);
            }
        }

        private Estimation CreateEstimation(Stop stop)
        {
            var estimation = new Estimation { StopId = stop.Id };
            var similarStops =
                _smartMoneyDbContext.Stops.Where(otherStop => otherStop.Location.Distance(stop.Location) < SameLocationRadios).ToList();
            var similarStopIds = similarStops.Select(similarStop =>similarStop.Id).ToArray();
            var transactions =
                _smartMoneyDbContext.Transactions.Where(transaction => similarStopIds.Contains(transaction.StopId))
                    .ToList();
            var average = transactions.Sum(transaction => transaction.Amount)/transactions.Count;
            estimation.Amount = average;

            return estimation;
        }
    }
}