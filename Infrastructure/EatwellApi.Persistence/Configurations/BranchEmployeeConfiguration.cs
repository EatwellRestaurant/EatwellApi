using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class BranchEmployeeConfiguration : IEntityTypeConfiguration<BranchEmployee>
    {
        public void Configure(EntityTypeBuilder<BranchEmployee> builder)
        {
            builder.HasOne(b => b.Branch).WithMany(b => b.BranchEmployees).HasForeignKey(b => b.BranchId);
        }
    }
}
