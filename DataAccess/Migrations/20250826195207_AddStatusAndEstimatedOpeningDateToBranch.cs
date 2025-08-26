using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusAndEstimatedOpeningDateToBranch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EstimatedOpeningDate",
                table: "Branches",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "Status",
                table: "Branches",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstimatedOpeningDate",
                table: "Branches");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Branches");
        }
    }
}
