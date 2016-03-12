using System;
using System.Web.Http;
using test.Models;

namespace test.Controllers
{
    public class UsesrController : ApiController
    {
        //CREATEUser
        public User CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            return user;
        }
    }
}