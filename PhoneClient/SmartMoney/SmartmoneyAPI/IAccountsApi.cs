﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Refit;
using SmartMoney.Models;

namespace SmartMoney.SmartmoneyAPI
{
    public interface IAccountsApi
    {
        [Get("/accounts")]
        Task<IEnumerable<Account>> Get(Guid userId);

        [Get("/accounts")]
        Task<Account> Get(Guid userId, Guid id);

        [Put("/accounts")]
        Task<string> Update(Account account);

        [Post("/accounts")]
        Task<Account> CreateAccount(Account account);
    }
}