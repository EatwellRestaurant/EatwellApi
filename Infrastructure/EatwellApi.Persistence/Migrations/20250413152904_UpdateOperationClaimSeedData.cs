using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateOperationClaimSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "User");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Kullanıcı");
        }
    }
}
