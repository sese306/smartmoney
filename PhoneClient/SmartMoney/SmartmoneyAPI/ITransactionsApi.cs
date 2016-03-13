using System.Threading.Tasks;
using Refit;
using SmartMoney.Models;

namespace SmartMoney.SmartmoneyAPI
{
    public interface ITransactionsApi
    {
        [Post("/transactions")]
        Task<Transaction> CreateTransaction(Transaction transaction);
    }
}
