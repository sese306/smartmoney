using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using SmartMoney.Models;

namespace SmartMoney.SmartmoneyAPI
{
    public interface ITransactionsApi
    {
        [Post("/transactions")]
        Task<Transaction> CreateTransaction(Transaction transaction);

        [Get("/transactions")]
        Task<IEnumerable<Transaction>> Get(Guid accountId);
    }
}
