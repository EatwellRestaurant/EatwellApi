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
            builder.HasData(
                new Country { Id = 1, Name = "Türkiye", IsActive = true },
                new Country { Id = 2, Name = "Filistin", IsActive = false },
                new Country { Id = 3, Name = "Azerbaycan", IsActive = false },
                new Country { Id = 4, Name = "Fransa", IsActive = false },
                new Country { Id = 5, Name = "Almanya", IsActive = false },
                new Country { Id = 6, Name = "İspanya", IsActive = false },
                new Country { Id = 7, Name = "İtalya", IsActive = false },
                new Country { Id = 8, Name = "Japonya", IsActive = false },
                new Country { Id = 9, Name = "Yunanistan", IsActive = false },
                new Country { Id = 10, Name = "Rusya", IsActive = false });
        }
    }
}
