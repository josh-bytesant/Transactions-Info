using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Transactions.Info.Core.DTOs;
using Transactions.Info.Core.Interfaces;
using Transactions.Info.Infrastructure.Data.Implementations;

namespace Transactions.Info.Extra.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountInfoController : ControllerBase
    {
        private readonly ILogger<AccountInfoController> _logger;
        private readonly ICustomerAccountInfoRepository _accountInfoRepo;

        public AccountInfoController(ILogger<AccountInfoController> logger, ICustomerAccountInfoRepository accountInfoRepo)
        {
            _logger = logger;
            _accountInfoRepo = accountInfoRepo;
        }

        [HttpGet("{accountNumber}")]
        public async Task<IActionResult> GetAccountInfo(string accountNumber)
        {
            try
            {
                var result = await _accountInfoRepo.GetCustomerAccountInfoAsync(accountNumber);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message} => {e.StackTrace}");
                return BadRequest("An error occurred");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCustomerAccountIndustry(UpdateCustomerAccountIndustryDTO model)
        {
            try
            {
                var result = await _accountInfoRepo.UpdateCustomerAccountIndustryAsync(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError($"{e.Message} => {e.StackTrace}");
                return BadRequest("An error occurred");
            }

        }


    }
}
