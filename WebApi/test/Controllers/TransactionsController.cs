using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class TransactionsController : ApiController
    {
        [HttpPost]
        public Transaction Create([FromBody]Transaction transaction)
        {
            var dbContext = new SmartMoneyDbContext();
            dbContext.Transactions.Add(transaction);
            dbContext.SaveChanges();

            return transaction;
        }

        [HttpGet]
        public IEnumerable<Transaction> Get(Guid accountId)
        {
            var dbContext = new SmartMoneyDbContext();
            return dbContext.Transactions.Where(transaction => transaction.AccountId == accountId).ToArray();
        }
    }
}