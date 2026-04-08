using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdminUserVerification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Verification" },
                values: new object[] { new DateTime(2026, 4, 8, 15, 58, 44, 26, DateTimeKind.Local).AddTicks(9536), true });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreateDate", "Verification" },
                values: new object[] { new DateTime(2026, 2, 17, 22, 13, 9, 640, DateTimeKind.Local).AddTicks(6435), null });
        }
    }
}
