using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class EstimationsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Estimation> Get(Guid userId)
        {
            var dbContext = new SmartMoneyDbContext();
            var nonEstimatedStops =
                dbContext.Stops.Where(
                    stop => dbContext.Transactions.Count(transaction => transaction.StopId == stop.Id) == 0 && stop.UserId == userId)
                    .ToList();
            var similarStopIds = nonEstimatedStops.Select(similarStop => similarStop.Id).ToArray();
            return dbContext.Estimations.Where(estimation => similarStopIds.Contains(estimation.StopId));
        }
    }
}