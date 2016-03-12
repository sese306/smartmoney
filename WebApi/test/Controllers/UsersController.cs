using System;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class UsersController : ApiController
    {
        [HttpPost]
        public User Create([FromBody]User user)
        {
            var dbContext = new SmartMoneyDbContext();
            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return user;
        }
    }
}