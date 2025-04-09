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
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasOne(u => u.User).WithMany(u => u.UserOperationClaims).HasForeignKey(u => u.UserId);
            builder.HasOne(u => u.OperationClaim).WithMany(o => o.UserOperationClaims).HasForeignKey(u => u.OperationClaimId);
        }
    }
}
