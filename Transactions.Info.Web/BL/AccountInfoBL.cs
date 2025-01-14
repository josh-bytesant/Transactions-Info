using Newtonsoft.Json;
using System.Text.Json;
using Transactions.Info.Core.DTOs;
using Transactions.Info.Infrastructure.Data.DBContexts;
using Transactions.Info.Infrastructure.Data.Encryption;
using Transactions.Info.Web.Models;
using Transactions.Info.Web.Services;

namespace Transactions.Info.Web.BL
{
    public class AccountInfoBL
    {
        private readonly AccountInfoDbContext _dbContext;
        private readonly AccountInfoService _accountInfoService;
        private readonly AESCryptography _crypto;
        private readonly string APPLICATION_USERNAME;
        public AccountInfoBL(AccountInfoDbContext dbContext, AccountInfoService accountInfoService, 
            AESCryptography crypto, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _accountInfoService = accountInfoService;
            _crypto = crypto;
            APPLICATION_USERNAME = configuration["ClientUserName"];
        }

        public async Task<GenericResponseDTO<AccountInfoDTO>> GetAccountInfo()
        {
            var apiLogin = _dbContext.Logins.FirstOrDefault(t => t.UserName == APPLICATION_USERNAME);
            if (apiLogin == null) { return new GenericResponseDTO<AccountInfoDTO> { Message = "Failed getting API login" }; };

            var response = await _accountInfoService.GetAccountInfoAsync("1234567890", apiLogin.UserName, apiLogin.Password);

            if(response.StatusCode != 200) { return new GenericResponseDTO<AccountInfoDTO> { Message = "GetAccountInfoAsync request failed" }; };

            var encryptedData = JsonConvert.DeserializeObject<GenericResponseDTO<string>>(response.Body);

            string decryptedData = _crypto.Decrypt(encryptedData.Data, APPLICATION_USERNAME);
            var data = JsonConvert.DeserializeObject<AccountInfoDTO>(decryptedData);
            return new GenericResponseDTO<AccountInfoDTO> { Status = true, Data = data };
        }
    }
}
