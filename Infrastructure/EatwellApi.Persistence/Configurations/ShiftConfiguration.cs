using EatwellApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EatwellApi.Persistence.Configurations
{
    public class ShiftConfiguration : IEntityTypeConfiguration<Shift>
    {
        public void Configure(EntityTypeBuilder<Shift> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).UseIdentityColumn();
            builder.Property(s => s.Day).HasMaxLength(50);


            builder.HasData(
                new Shift() { Id = 1, Day = "Pazartesi" },
                new Shift() { Id = 2, Day = "Salı" },
                new Shift() { Id = 3, Day = "Çarşamba" },
                new Shift() { Id = 4, Day = "Perşembe" },
                new Shift() { Id = 5, Day = "Cuma" },
                new Shift() { Id = 6, Day = "Cumartesi" },
                new Shift() { Id = 7, Day = "Pazar" });
        }
    }
}
