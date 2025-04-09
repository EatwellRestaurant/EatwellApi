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
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn();
            
            builder.Property(b => b.IsDeleted).HasDefaultValue(false);
            builder.Property(b => b.CreateDate).HasDefaultValue(DateTime.Now);

            builder.UseTpcMappingStrategy();
        }
    }
}
