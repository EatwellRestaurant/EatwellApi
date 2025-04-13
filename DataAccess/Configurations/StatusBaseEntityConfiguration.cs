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
    public class StatusBaseEntityConfiguration : IEntityTypeConfiguration<StatusBaseEntity>
    {
        public void Configure(EntityTypeBuilder<StatusBaseEntity> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).UseIdentityColumn();

            builder.Property(b => b.IsActive).HasDefaultValue(false);

            builder.UseTpcMappingStrategy();
        }
    }
}
