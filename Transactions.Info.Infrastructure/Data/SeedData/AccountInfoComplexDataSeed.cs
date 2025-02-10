using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Common;
using Transactions.Info.Infrastructure.Data.DBContexts;

namespace Transactions.Info.Infrastructure.Data.SeedData
{
    public static class AccountInfoComplexDataSeed
    {
        public static void Initialize(AccountInfoDbContext context)
        {
            
            if (!context.Industries.Any())
            {
                var industries = new List<Industry>
            {
                new Industry{ Name = "Manufacturing",
                            CustomerAccounts = new List<CustomerAccountInfo> {
                            new CustomerAccountInfo{ AccountNumber = "1234567890"}},
                            IndustryFields = new List<IndustryField>
                            {
                                new IndustryField{ Field = "Invoice Number" },
                                new IndustryField{ Field = "Quantity" },
                                new IndustryField{ Field = "Delivery Address" }

                            } },
                new Industry{ Name = "Education",
                            CustomerAccounts = new List<CustomerAccountInfo> {
                            new CustomerAccountInfo{ AccountNumber = "2345678901"}},
                            IndustryFields = new List<IndustryField>
                            {
                                new IndustryField{ Field = "Matric Number" },
                                new IndustryField{ Field = "Level " },
                                new IndustryField{ Field = "Course" }

                            } },
                new Industry{ Name = "Telcom",
                            CustomerAccounts = new List<CustomerAccountInfo> {
                            new CustomerAccountInfo{ AccountNumber = "3456789012"}},
                            IndustryFields = new List<IndustryField>
                            {
                                new IndustryField{ Field = "GSM Number" },
                                new IndustryField{ Field = "Network" },
                                new IndustryField{ Field = "Residential Address" }

                            } }
            };

                context.Industries.AddRange(industries);
                context.SaveChanges();
            }
            
        }
    }
}
