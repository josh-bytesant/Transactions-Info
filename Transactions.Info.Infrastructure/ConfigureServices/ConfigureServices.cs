using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Interfaces;
using Transactions.Info.Infrastructure.Data.DBContexts;
using Transactions.Info.Infrastructure.Data.Encryption;
using Transactions.Info.Infrastructure.Data.Implementations;

namespace Transactions.Info.Infrastructure.ConfigureServices
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountInfoDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("AccountInfoConnection"),
                     b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
            });
            services.AddScoped<AESCryptography>();
            services.AddScoped<UserContextRepository>();
            services.AddScoped<ICustomerAccountInfoRepository, CustomerAccountInfoRepository>();
            return services;
        }
    }
}
