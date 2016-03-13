using System.Threading.Tasks;
using Refit;
using SmartMoney.Models;

namespace SmartMoney.SmartmoneyAPI
{
   public interface IStopsApi
   {
       [Post("/stops")]
       Task<Stop> CreateStop(Stop stop);

       [Put("/stops")]
       Task<string> Update(Stop stop);
    }

}
