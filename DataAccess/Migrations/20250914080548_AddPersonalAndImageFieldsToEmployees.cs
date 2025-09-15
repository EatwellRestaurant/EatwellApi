using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPersonalAndImageFieldsToEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "MaritalStatus",
                table: "Employees",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)1);

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Employees",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "MaritalStatus",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Employees");
        }
    }
}
