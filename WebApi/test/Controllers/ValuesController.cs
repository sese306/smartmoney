using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace test.Controllers
{
    public class UsersController : ApiController
    {
        // GET api/values
        public IEnumerable<User> Get()
        {
            return new User[] {};
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        //CREATEUser
        public class CreateUser
        {

        }

        //CREATEAccount

        public class CreateAccount
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}