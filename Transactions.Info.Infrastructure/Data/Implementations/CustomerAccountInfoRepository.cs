using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Common;
using Transactions.Info.Core.Interfaces;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Infrastructure.Data.Implementations
{
    public class CustomerAccountInfoRepository : ICustomerAccountInfoRepository
    {
        private readonly AccountInfoDbContext _dbContext;
        public CustomerAccountInfoRepository(AccountInfoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IReadOnlyList<string>> GetCustomerAccountIndustries()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerAccountInfo> GetCustomerAccountInfoAsync(string accountNumber)
        {
            return await _dbContext.CustomerAccounts.FirstOrDefaultAsync(t => t.AccountNumber == accountNumber);
        }

        public Task<CustomerAccountInfo> GetCustomerAccountInfoByIndustryAsync(string industry)
        {
            throw new NotImplementedException();
        }
    }
}
