using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Authentication;
using Transactions.Info.Core.Entities.Common;
using Transactions.Info.Core.Entities.Encryption;

namespace Transactions.Info.Infrastructure.Data.DBContexts
{
    public class AccountInfoDbContext : DbContext
    {
        public AccountInfoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<APILogin> Logins { get; set; }
        public DbSet<ApplicationUserKey> ApplicationUserKeys { get; set; }
        
        public DbSet<IndustryField> IndustryFields { get; set; }
        public DbSet<CustomerAccountInfo> CustomerAccounts { get; set; }
        public DbSet<Industry> Industries { get; set; }
    }
}
