using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.DTOs;
using Transactions.Info.Core.Entities.Common;

namespace Transactions.Info.Core.Interfaces
{
    public interface ICustomerAccountInfoRepository
    {
        Task<GenericResponseDTO<string>> GetCustomerAccountInfoAsync(string accountNumber);
        Task<GenericResponseDTO<string>> GetAllCustomerAccountInfoAsync();
        Task<GenericResponseDTO<string>> UpdateCustomerAccountIndustryAsync(UpdateCustomerAccountIndustryDTO updateCustomerAccountIndustry);
    }
}
