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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasOne(c => c.Country).WithMany(c => c.Cities).HasForeignKey(c => c.CountryId);


            builder.HasData(
                new City { Id = 1, CountryId = 1, Name = "Adana" },
                new City { Id = 2, CountryId = 1, Name = "Adıyaman" },
                new City { Id = 3, CountryId = 1, Name = "Afyonkarahisar" },
                new City { Id = 4, CountryId = 1, Name = "Ağrı" },
                new City { Id = 5, CountryId = 1, Name = "Amasya" },
                new City { Id = 6, CountryId = 1, Name = "Ankara" },
                new City { Id = 7, CountryId = 1, Name = "Antalya" },
                new City { Id = 8, CountryId = 1, Name = "Artvin" },
                new City { Id = 9, CountryId = 1, Name = "Aydın" },
                new City { Id = 10, CountryId = 1, Name = "Balıkesir" },
                new City { Id = 11, CountryId = 1, Name = "Bilecik" },
                new City { Id = 12, CountryId = 1, Name = "Bingöl" },
                new City { Id = 13, CountryId = 1, Name = "Bitlis" },
                new City { Id = 14, CountryId = 1, Name = "Bolu" },
                new City { Id = 15, CountryId = 1, Name = "Burdur" },
                new City { Id = 16, CountryId = 1, Name = "Bursa" },
                new City { Id = 17, CountryId = 1, Name = "Çanakkale" },
                new City { Id = 18, CountryId = 1, Name = "Çankırı" },
                new City { Id = 19, CountryId = 1, Name = "Çorum" },
                new City { Id = 20, CountryId = 1, Name = "Denizli" },
                new City { Id = 21, CountryId = 1, Name = "Diyarbakır" },
                new City { Id = 22, CountryId = 1, Name = "Edirne" },
                new City { Id = 23, CountryId = 1, Name = "Elazığ" },
                new City { Id = 24, CountryId = 1, Name = "Erzincan" },
                new City { Id = 25, CountryId = 1, Name = "Erzurum" },
                new City { Id = 26, CountryId = 1, Name = "Eskişehir" },
                new City { Id = 27, CountryId = 1, Name = "Gaziantep" },
                new City { Id = 28, CountryId = 1, Name = "Giresun" },
                new City { Id = 29, CountryId = 1, Name = "Gümüşhane" },
                new City { Id = 30, CountryId = 1, Name = "Hakkari" },
                new City { Id = 31, CountryId = 1, Name = "Hatay" },
                new City { Id = 32, CountryId = 1, Name = "Isparta" },
                new City { Id = 33, CountryId = 1, Name = "Mersin" },
                new City { Id = 34, CountryId = 1, Name = "İstanbul" },
                new City { Id = 35, CountryId = 1, Name = "İzmir" },
                new City { Id = 36, CountryId = 1, Name = "Kars" },
                new City { Id = 37, CountryId = 1, Name = "Kastamonu" },
                new City { Id = 38, CountryId = 1, Name = "Kayseri" },
                new City { Id = 39, CountryId = 1, Name = "Kırklareli" },
                new City { Id = 40, CountryId = 1, Name = "Kırşehir" },
                new City { Id = 41, CountryId = 1, Name = "Kocaeli" },
                new City { Id = 42, CountryId = 1, Name = "Konya" },
                new City { Id = 43, CountryId = 1, Name = "Kütahya" },
                new City { Id = 44, CountryId = 1, Name = "Malatya" },
                new City { Id = 45, CountryId = 1, Name = "Manisa" },
                new City { Id = 46, CountryId = 1, Name = "Kahramanmaraş" },
                new City { Id = 47, CountryId = 1, Name = "Mardin" },
                new City { Id = 48, CountryId = 1, Name = "Muğla" },
                new City { Id = 49, CountryId = 1, Name = "Muş" },
                new City { Id = 50, CountryId = 1, Name = "Nevşehir" },
                new City { Id = 51, CountryId = 1, Name = "Niğde" },
                new City { Id = 52, CountryId = 1, Name = "Ordu" },
                new City { Id = 53, CountryId = 1, Name = "Rize" },
                new City { Id = 54, CountryId = 1, Name = "Sakarya" },
                new City { Id = 55, CountryId = 1, Name = "Samsun" },
                new City { Id = 56, CountryId = 1, Name = "Siirt" },
                new City { Id = 57, CountryId = 1, Name = "Sinop" },
                new City { Id = 58, CountryId = 1, Name = "Sivas" },
                new City { Id = 59, CountryId = 1, Name = "Tekirdağ" },
                new City { Id = 60, CountryId = 1, Name = "Tokat" },
                new City { Id = 61, CountryId = 1, Name = "Trabzon" },
                new City { Id = 62, CountryId = 1, Name = "Tunceli" },
                new City { Id = 63, CountryId = 1, Name = "Şanlıurfa" },
                new City { Id = 64, CountryId = 1, Name = "Uşak" },
                new City { Id = 65, CountryId = 1, Name = "Van" },
                new City { Id = 66, CountryId = 1, Name = "Yozgat" },
                new City { Id = 67, CountryId = 1, Name = "Zonguldak" },
                new City { Id = 68, CountryId = 1, Name = "Aksaray" },
                new City { Id = 69, CountryId = 1, Name = "Bayburt" },
                new City { Id = 70, CountryId = 1, Name = "Karaman" },
                new City { Id = 71, CountryId = 1, Name = "Kırıkkale" },
                new City { Id = 72, CountryId = 1, Name = "Batman" },
                new City { Id = 73, CountryId = 1, Name = "Şırnak" },
                new City { Id = 74, CountryId = 1, Name = "Bartın" },
                new City { Id = 75, CountryId = 1, Name = "Ardahan" },
                new City { Id = 76, CountryId = 1, Name = "Iğdır" },
                new City { Id = 77, CountryId = 1, Name = "Yalova" },
                new City { Id = 78, CountryId = 1, Name = "Karabük" },
                new City { Id = 79, CountryId = 1, Name = "Kilis" },
                new City { Id = 80, CountryId = 1, Name = "Osmaniye" },
                new City { Id = 81, CountryId = 1, Name = "Düzce" }
                );
        }
    }
}
