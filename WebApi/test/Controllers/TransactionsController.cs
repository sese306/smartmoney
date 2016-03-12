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
    }
}