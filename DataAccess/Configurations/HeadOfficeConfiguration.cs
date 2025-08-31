using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class HeadOfficeConfiguration : IEntityTypeConfiguration<HeadOffice>
    {
        public void Configure(EntityTypeBuilder<HeadOffice> builder)
        {   
            builder.Property(h => h.Address).HasMaxLength(400);
            
            builder.Property(h => h.Phone).HasMaxLength(14);
            
            builder.Property(h => h.Email).HasMaxLength(254);
            
            builder.Property(h => h.MidWeekWorkingHours).HasMaxLength(14);
            
            builder.Property(h => h.WeekendWorkingHours).HasMaxLength(14);
            
            builder.Property(h => h.SpecialNote).HasMaxLength(400);

            builder.HasData(new HeadOffice
            { 
                Id = 1, 
                Address = "Eğriçam Mahallesi, Adnan Menderes Bulvarı, Sokak: 5, No: 40 Avcılar / İstanbul", 
                Phone = "0216 123 45 67", 
                Email = "avcilar@firma.com",
                MidWeekWorkingHours = "09:00 - 23:00",
                WeekendWorkingHours = "11:00 - 22:00",
                SpecialNote = "* Şubelerimize göre değişiklik gösterebilir.",
                Facebook = "https://facebook.com/eatwellrestaurant",
                Instagram = "https://instagram.com/eatwell_restaurant",
                Twitter = "https://twitter.com/eatwell_tr",
                Gmail = "https://business.google.com/eatwell"
            });
        }
    }
}
