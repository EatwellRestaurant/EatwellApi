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
    public class YearConfiguration : IEntityTypeConfiguration<Year>
    {
        public void Configure(EntityTypeBuilder<Year> builder)
        {
            builder.Property(y => y.Name).HasMaxLength(4);

            builder.HasData(new Year() { Id = 2, Name = DateTime.Now.Year.ToString() });

        }
    }
}
