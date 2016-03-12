using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class AccountsController : ApiController
    {
        public IEnumerable<Account> Get(Guid userId)
        {
            var dbContext = new SmartMoneyDbContext();
            return dbContext.Accounts.Where(account => account.UserId == userId).ToArray();
        }

        [HttpGet]
        public Account Get(Guid userId, Guid id)
        {
            var dbContext = new SmartMoneyDbContext();
            var account = dbContext.Accounts.FirstOrDefault(a => a.UserId == userId && a.Id == id);
           
            return account;
        }

        [HttpPut]
        public void Put([FromBody]Account account)
        {
            var dbContext = new SmartMoneyDbContext();
            dbContext.Accounts.Attach(account);
            dbContext.SaveChanges();
        }

        [HttpPost]
        public Account Create([FromBody]Account account)
        {
            var dbContext = new SmartMoneyDbContext();
            dbContext.Accounts.Add(account);
            dbContext.SaveChanges();

            return account;
        }
    }
}