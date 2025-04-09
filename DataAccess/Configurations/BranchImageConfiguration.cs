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
    public class BranchImageConfiguration : IEntityTypeConfiguration<BranchImage>
    {
        public void Configure(EntityTypeBuilder<BranchImage> builder)
        {
            builder.HasOne(b => b.Branch).WithMany(b => b.BranchImages).HasForeignKey(b => b.BranchId);
        }
    }
}
