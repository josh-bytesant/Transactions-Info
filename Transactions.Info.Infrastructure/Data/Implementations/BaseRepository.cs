using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Infrastructure.Data.Implementations
{

    public class BaseRepository
    {
        public string ApplicationUserKey;
        public BaseRepository(AccountInfoDbContext dbContext, string UserName)
        {
            var result = dbContext.ApplicationUserKeys.FirstOrDefault(t => t.UserName == UserName);
            if (result == null)
            {

            }
        }
    }
}
