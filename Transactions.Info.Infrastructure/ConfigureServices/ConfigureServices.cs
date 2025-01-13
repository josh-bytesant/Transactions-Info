using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Infrastructure.ConfigureServices
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AccountInfoDbContext>(opt =>
            {
                opt.UseInMemoryDatabase(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
