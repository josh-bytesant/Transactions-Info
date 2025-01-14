using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.DTOs;
using Transactions.Info.Core.Entities.Common;
using Transactions.Info.Core.Extensions;
using Transactions.Info.Core.Interfaces;
using Transactions.Info.Infrastructure.Data.DBContexts;
using Transactions.Info.Infrastructure.Data.Encryption;

namespace Transactions.Info.Infrastructure.Data.Implementations
{
    public class CustomerAccountInfoRepository : ICustomerAccountInfoRepository
    {
        private readonly AccountInfoDbContext _dbContext;
        private readonly AESCryptography _crypto;
        private readonly UserContextRepository _userContext;

        public CustomerAccountInfoRepository(AccountInfoDbContext dbContext, AESCryptography crypto, UserContextRepository userContext)
        {
            _dbContext = dbContext;
            _crypto = crypto;
            _userContext = userContext;
        }

        public async Task<GenericResponseDTO<string>> GetCustomerAccountInfoAsync(string accountNumber)
        {
            var dbResult = await _dbContext.CustomerAccounts
                .Include(i => i.Industry).ThenInclude(f => f.IndustryFields)
                .FirstOrDefaultAsync(t => t.AccountNumber == accountNumber);
            var data = _crypto.Encrypt(dbResult.SerializeThis(), _userContext.CurrrentUser);
            return new GenericResponseDTO<string> { Status = true, Message = "Success", Data = data };
        }

        public async Task<GenericResponseDTO<string>> GetAllCustomerAccountInfoAsync()
        {
            var dbResult = await _dbContext.CustomerAccounts
                .Include(i => i.Industry).ThenInclude(f => f.IndustryFields).ToListAsync();

            var data = _crypto.Encrypt(dbResult.SerializeThis(), _userContext.CurrrentUser);
            return new GenericResponseDTO<string> { Status = true, Message = "Success", Data = data };
        }
    }
}
