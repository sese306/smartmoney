using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class TransactionsController : ApiController
    {
        public Transaction Create(Transaction transaction)
        {
            transaction.Id = new Guid();
            return transaction;
        }
    }
}