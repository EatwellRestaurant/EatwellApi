using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class TableConfiguration : IEntityTypeConfiguration<Table>
    {
        public void Configure(EntityTypeBuilder<Table> builder)
        {
            builder.Property(t => t.Name).HasMaxLength(50);


            builder.HasOne(t => t.Branch).WithMany(b => b.Tables).HasForeignKey(t => t.BranchId);
        }
    }
}
