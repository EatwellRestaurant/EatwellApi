using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class MonthConfiguration : IEntityTypeConfiguration<Month>
    {
        public void Configure(EntityTypeBuilder<Month> builder)
        {
            builder.Property(m => m.Name).HasMaxLength(15);

            builder.HasData(
                new Month() { Id = 10, YearId = 2, Name = "Ocak" },
                new Month() { Id = 11, YearId = 2, Name = "Şubat" },
                new Month() { Id = 12, YearId = 2, Name = "Mart" },
                new Month() { Id = 13, YearId = 2, Name = "Nisan" },
                new Month() { Id = 14, YearId = 2, Name = "Mayıs" },
                new Month() { Id = 15, YearId = 2, Name = "Haziran" },
                new Month() { Id = 16, YearId = 2, Name = "Temmuz" },
                new Month() { Id = 17, YearId = 2, Name = "Ağustos" },
                new Month() { Id = 18, YearId = 2, Name = "Eylül" },
                new Month() { Id = 19, YearId = 2, Name = "Ekim" },
                new Month() { Id = 20, YearId = 2, Name = "Kasım" },
                new Month() { Id = 21, YearId = 2, Name = "Aralık" }
            );


            builder.HasOne(m => m.Year).WithMany(y => y.Months).HasForeignKey(m => m.YearId);
        }
    }
}
