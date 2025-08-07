using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPageContentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PageContents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Page = table.Column<byte>(type: "tinyint", nullable: false),
                    Section = table.Column<byte>(type: "tinyint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 8, 7, 15, 57, 53, 160, DateTimeKind.Local).AddTicks(2290)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContents", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "PageContents",
                columns: new[] { "Id", "Description", "ImageName", "ImagePath", "Page", "Section", "UpdateDate" },
                values: new object[,]
                {
                    { 1, null, "home-hero.jpg", "https://eatwellimg.blob.core.windows.net/images/home-hero.jpg", (byte)1, (byte)1, null },
                    { 2, "Eatwell, sadece bir restoran değil, bir yaşam tarzıdır. Her bir detayımız, İstanbul'un güzelliklerini ve trendlerini yansıtmak için seçildi. <br> Estetik, minimalist, modern ve elegan atmosferimizle sizleri karşılamak; Eatwell'in sizlere sunduğu ayrıcalıklardan sadece biridir. Eatwell ailesi olarak; sadece yemek sunmuyoruz, sizleri bir yaşam tarzına davet ediyoruz.", "home-about-section.jpg", "https://eatwellimg.blob.core.windows.net/images/home-about-section.jpg", (byte)1, (byte)2, null },
                    { 3, null, "home-menu-section.jpg", "https://eatwellimg.blob.core.windows.net/images/home-menu-section.jpg", (byte)1, (byte)3, null },
                    { 4, null, "about-hero.jpeg", "https://eatwellimg.blob.core.windows.net/images/about-hero.jpeg", (byte)2, (byte)1, null },
                    { 5, "Eatwell, tarihiyle, kültürüyle ve trendleriyle özdeşleşmiş olan İstanbul'un en seçkin noktalarında bulunur. Şehrin enerjisi, Eatwell'in zarif atmosferinde buluşup sizlere unutulmaz bir mekân deneyimi yaşatır. <br> Menümüz, damak zevkinizin sınırlarını zorlayacak özel tatlar içerir. Sabah kahvaltılarından, nefis et yemeklerine, benzersiz salatalar ve dürümlerden, zengin kebap ve ızgaralara kadar geniş bir yelpazede seçenekler sunar.", null, null, (byte)2, (byte)2, null },
                    { 6, "Her tabak, aşçılarımızın özenle seçtiği en kaliteli malzemelerle hazırlanır ve özel olarak tasarlanmış menümüzdeki her yemek, sizi lezzetin muhteşem dünyasına çıkarır. <br> Biz, konuklarımıza sadece bir yemek değil, bir anı sunarız. Bizim için her bir müşteri, aile üyesidir. Eatwell'e adım attığınızda, yemekten çok daha fazlasını paylaşırız ve sizi bu samimi atmosferde ağırlamaktan mutluluk duyarız. Gelin, birlikte estetik bir lezzet yolculuğuna çıkalım!", null, null, (byte)2, (byte)2, null },
                    { 7, null, "about-chef-section.jpg", "https://eatwellimg.blob.core.windows.net/images/about-chef-section.jpg", (byte)2, (byte)4, null },
                    { 8, null, "menu-hero.jpg", "https://eatwellimg.blob.core.windows.net/images/menu-hero.jpg", (byte)3, (byte)1, null },
                    { 9, null, "gallery-hero.jpg", "https://eatwellimg.blob.core.windows.net/images/gallery-hero.jpg", (byte)4, (byte)1, null },
                    { 10, null, "reservation-hero.jpg", "https://eatwellimg.blob.core.windows.net/images/reservation-hero.jpg", (byte)5, (byte)1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PageContents");
        }
    }
}
