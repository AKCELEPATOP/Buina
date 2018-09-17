using BuinyaModel;
using BuinyaService.Interfaces;
using BuinyaService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuinyaService.Implementations
{
    public class AccountService : IAccount
    {
        private readonly string tableName = "account";

        public AccountService() { }

        public async Task<List<Account>> GetTable()
        {
            return await DbWork.SelectTable<Account>(tableName);
        }
    }
}
