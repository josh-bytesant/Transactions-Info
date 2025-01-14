using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Transactions.Info.Core.Extensions.ClaimsPrincipalExtensions;

namespace Transactions.Info.Infrastructure.Data.Implementations
{
    public class UserContextRepository
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly string CurrrentUser;
        public UserContextRepository(IHttpContextAccessor httpContextAccessor)
        {
            CurrrentUser = httpContextAccessor.HttpContext.User.GetUserName() ?? string.Empty;
           // _httpContextAccessor = httpContextAccessor;

        }

        //public string GetCurrentUser()
        //{
        //   return _httpContextAccessor.HttpContext.User.Identity.Name ?? string.Empty;
        //}
    }
}
