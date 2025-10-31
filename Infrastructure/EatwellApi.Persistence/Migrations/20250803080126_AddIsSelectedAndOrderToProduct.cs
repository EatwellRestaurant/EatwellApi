using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSelectedAndOrderToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSelected",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Order",
                table: "Products",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSelected",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "Products");
        }
    }
}
