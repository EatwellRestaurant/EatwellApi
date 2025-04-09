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
    public class BranchConfiguration : IEntityTypeConfiguration<Branch>
    {
        public void Configure(EntityTypeBuilder<Branch> builder)
        {
            builder.HasOne(b => b.City).WithMany(c => c.Branches).HasForeignKey(b => b.CityId);
        }
    }
}
