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
    public class MealCategoryConfiguration : IEntityTypeConfiguration<MealCategory>
    {
        public void Configure(EntityTypeBuilder<MealCategory> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(250);
        }
    }
}
