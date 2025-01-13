using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Common;

namespace Transactions.Info.Core.Interfaces
{
    public interface ICustomerAccountInfoRepository
    {
        Task<CustomerAccountInfo> GetCustomerAccountInfoAsync(string accountNumber);
        Task<CustomerAccountInfo> GetCustomerAccountInfoByIndustryAsync(string industry);
        Task<IReadOnlyList<string>> GetCustomerAccountIndustries();
    }
}
