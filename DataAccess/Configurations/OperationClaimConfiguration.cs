using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasData(
                new OperationClaim { Id = 1, Name = "Admin" },
                new OperationClaim { Id = 2, Name = "Kullanıcı" }
                );
        }
    }
}
