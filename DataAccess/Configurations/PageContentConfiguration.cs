using Entities.Concrete;
using Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class PageContentConfiguration : IEntityTypeConfiguration<PageContent>
    {
        public void Configure(EntityTypeBuilder<PageContent> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).UseIdentityColumn();

            builder.Property(p => p.CreateDate).HasDefaultValue(DateTime.Now);

            builder.HasData(
                new PageContent { Id = 1, Page = (byte)PageEnum.Home, Section = (byte)SectionEnum.Hero, ImagePath = "https://eatwellimg.blob.core.windows.net/images/home-hero.jpg", ImageName = "home-hero.jpg" },
                
                new PageContent { Id = 2, Page = (byte)PageEnum.Home, Section = (byte)SectionEnum.AboutSection, ImagePath = "https://eatwellimg.blob.core.windows.net/images/home-about-section.jpg", ImageName = "home-about-section.jpg", Description = "Eatwell, sadece bir restoran değil, bir yaşam tarzıdır. Her bir detayımız, İstanbul'un güzelliklerini ve trendlerini yansıtmak için seçildi. <br> Estetik, minimalist, modern ve elegan atmosferimizle sizleri karşılamak; Eatwell'in sizlere sunduğu ayrıcalıklardan sadece biridir. Eatwell ailesi olarak; sadece yemek sunmuyoruz, sizleri bir yaşam tarzına davet ediyoruz." },
                
                new PageContent { Id = 3, Page = (byte)PageEnum.Home, Section = (byte)SectionEnum.MenuSection, ImagePath = "https://eatwellimg.blob.core.windows.net/images/home-menu-section.jpg", ImageName = "home-menu-section.jpg" },
                
                new PageContent { Id = 4, Page = (byte)PageEnum.About, Section = (byte)SectionEnum.Hero, ImagePath = "https://eatwellimg.blob.core.windows.net/images/about-hero.jpeg", ImageName = "about-hero.jpeg" },
                
                new PageContent { Id = 5, Page = (byte)PageEnum.About, Section = (byte)SectionEnum.AboutSection, Description = "Eatwell, tarihiyle, kültürüyle ve trendleriyle özdeşleşmiş olan İstanbul'un en seçkin noktalarında bulunur. Şehrin enerjisi, Eatwell'in zarif atmosferinde buluşup sizlere unutulmaz bir mekân deneyimi yaşatır. <br> Menümüz, damak zevkinizin sınırlarını zorlayacak özel tatlar içerir. Sabah kahvaltılarından, nefis et yemeklerine, benzersiz salatalar ve dürümlerden, zengin kebap ve ızgaralara kadar geniş bir yelpazede seçenekler sunar." },
                
                new PageContent { Id = 6, Page = (byte)PageEnum.About, Section = (byte)SectionEnum.AboutSection, Description = "Her tabak, aşçılarımızın özenle seçtiği en kaliteli malzemelerle hazırlanır ve özel olarak tasarlanmış menümüzdeki her yemek, sizi lezzetin muhteşem dünyasına çıkarır. <br> Biz, konuklarımıza sadece bir yemek değil, bir anı sunarız. Bizim için her bir müşteri, aile üyesidir. Eatwell'e adım attığınızda, yemekten çok daha fazlasını paylaşırız ve sizi bu samimi atmosferde ağırlamaktan mutluluk duyarız. Gelin, birlikte estetik bir lezzet yolculuğuna çıkalım!" },
                
                new PageContent { Id = 7, Page = (byte)PageEnum.About, Section = (byte)SectionEnum.ChefSection, ImagePath = "https://eatwellimg.blob.core.windows.net/images/about-chef-section.jpg", ImageName = "about-chef-section.jpg" },
                
                new PageContent { Id = 8, Page = (byte)PageEnum.Menu, Section = (byte)SectionEnum.Hero, ImagePath = "https://eatwellimg.blob.core.windows.net/images/menu-hero.jpg", ImageName = "menu-hero.jpg" },
                
                new PageContent { Id = 9, Page = (byte)PageEnum.Gallery, Section = (byte)SectionEnum.Hero, ImagePath = "https://eatwellimg.blob.core.windows.net/images/gallery-hero.jpg", ImageName = "gallery-hero.jpg" },
                
                new PageContent { Id = 10, Page = (byte)PageEnum.Reservation, Section = (byte)SectionEnum.Hero, ImagePath = "https://eatwellimg.blob.core.windows.net/images/reservation-hero.jpg", ImageName = "reservation-hero.jpg" }
                );
        }
    }
}
