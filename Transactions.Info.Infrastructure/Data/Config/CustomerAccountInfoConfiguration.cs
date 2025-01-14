using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Transactions.Info.Core.Entities.Common;

namespace Transactions.Info.Infrastructure.Data.Config
{
    public class CustomerAccountInfoConfiguration : IEntityTypeConfiguration<CustomerAccountInfo>
    {
        public void Configure(EntityTypeBuilder<CustomerAccountInfo> builder)
        {
            builder.HasIndex(p => p.AccountNumber)
                .IsUnique();
        }
    }
}
