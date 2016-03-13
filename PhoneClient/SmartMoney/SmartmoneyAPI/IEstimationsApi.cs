using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using SmartMoney.Models;

namespace SmartMoney.SmartmoneyAPI
{
    public interface IEstimationsApi
    {
        [Get("/estimations")]
        Task<IEnumerable<Estimation>> GetAll(Guid userId);
    }
}