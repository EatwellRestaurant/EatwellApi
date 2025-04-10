using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBaseEntityToMealCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "MealCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2025, 4, 10, 16, 0, 4, 448, DateTimeKind.Local).AddTicks(8988));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "MealCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MealCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "MealCategories",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "MealCategories");

            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "MealCategories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MealCategories");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "MealCategories");
        }
    }
}
