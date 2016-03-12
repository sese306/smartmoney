using System;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class StopsController : ApiController
    {
        // PUT api/<controller>/5
        public void Put([FromBody]Stop stop)
        {
        }

        public Stop Create(Stop stop)
        {
            stop.Id = Guid.NewGuid();
            return stop;
        }
    }
}