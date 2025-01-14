using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Authentication;
using Transactions.Info.Core.Entities.Common;
using Transactions.Info.Core.Entities.Encryption;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Infrastructure.Data.SeedData
{
    public class AccountInfoContextSeed
    {
        public static async Task SeedAsync(AccountInfoDbContext context)
        {
            if (!context.Logins.Any())
            {
                var APILoginData = File.ReadAllText("../Transactions.Info.Infrastructure/Data/SeedData/APILogin.json");
                var APILogins = JsonSerializer.Deserialize<List<APILogin>>(APILoginData);
                context.Logins.AddRange(APILogins);
            }

            if (!context.ApplicationUserKeys.Any())
            {
                var ApplicationUserKeyData = File.ReadAllText("../Transactions.Info.Infrastructure/Data/SeedData/ApplicationUserKey.json");
                var ApplicationUserKeys = JsonSerializer.Deserialize<List<ApplicationUserKey>>(ApplicationUserKeyData);
                context.ApplicationUserKeys.AddRange(ApplicationUserKeys);
            }



            if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
