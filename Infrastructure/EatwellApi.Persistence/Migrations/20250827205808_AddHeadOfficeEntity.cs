using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddHeadOfficeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadOffices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    MidWeekWorkingHours = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    WeekendWorkingHours = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    SpecialNote = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gmail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOffices", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "HeadOffices",
                columns: new[] { "Id", "Address", "Email", "Facebook", "Gmail", "Instagram", "MidWeekWorkingHours", "Phone", "SpecialNote", "Twitter", "WeekendWorkingHours" },
                values: new object[] { 1, "Eğriçam Mahallesi, Adnan Menderes Bulvarı, Sokak: 5, No: 40 Avcılar / İstanbul", "avcilar@firma.com", "https://facebook.com/eatwellrestaurant", "https://business.google.com/eatwell", "https://instagram.com/eatwell_restaurant", "09:00 - 23:00", "0216 123 45 67", "*Şubelerimize göre değişiklik gösterebilir.", "https://twitter.com/eatwell_tr", "11:00 - 22:00" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadOffices");
        }
    }
}
