using System;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class StopsController : ApiController
    {
        [HttpPost]
        public Stop Create([FromBody]Stop stop)
        {
            var dbContext = new SmartMoneyDbContext();
            dbContext.Stops.Add(stop);
            dbContext.SaveChanges();

            return stop;
        }

        [HttpPut]
        public void Put([FromBody]Stop stop)
        {
            var dbContext = new SmartMoneyDbContext();
            dbContext.Stops.Attach(stop);
            dbContext.SaveChanges();
        }
    }
}