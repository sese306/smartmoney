using System;
using System.Collections.Generic;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class AccountsController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Account> Get()
        {
            return new Account[] {};
        }

        // GET api/users/userId/accounts/id
        [HttpGet]
        public Account Get(Guid userId, Guid id )
        {
            return new Account
            {
                Balance = 12.4m,
                Id = Guid.NewGuid(),
                Type = 0,
                UserId = userId
            };
        }

        // PUT api/<controller>/5
        public void Put([FromBody]Account account)
        {

        }

        public Account Create(Account account)
        {
            account.Id = Guid.NewGuid();
            return account;
        }
    }
}