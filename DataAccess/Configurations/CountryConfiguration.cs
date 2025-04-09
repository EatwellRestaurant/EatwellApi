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
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(new Country { Id = 1, Name = "Türkiye" });
        }
    }
}
