using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityToReservation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 14, 13, 53, 32, 79, DateTimeKind.Local).AddTicks(7755));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Reservations",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Reservations");
        }
    }
}
