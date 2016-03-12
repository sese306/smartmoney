using System.Threading.Tasks;
using Refit;
using SmartMoney.Models;

namespace SmartMoney.SmartmoneyAPI
{
    public interface IUsersApi
    {
        [Post("/users")]
        Task<User> Createuser(User user);
    }
}