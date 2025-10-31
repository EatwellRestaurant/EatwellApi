using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class BranchImageConfiguration : IEntityTypeConfiguration<BranchImage>
    {
        public void Configure(EntityTypeBuilder<BranchImage> builder)
        {
            builder.HasOne(b => b.Branch).WithMany(b => b.BranchImages).HasForeignKey(b => b.BranchId);
        }
    }
}
