using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropProgressPercentageColumnFromEmployeeTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeTask_ProgressPercentage_Range",
                table: "EmployeeTasks");

            migrationBuilder.DropColumn(
                name: "ProgressPercentage",
                table: "EmployeeTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "ProgressPercentage",
                table: "EmployeeTasks",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeTask_ProgressPercentage_Range",
                table: "EmployeeTasks",
                sql: "[ProgressPercentage] BETWEEN 0 AND 100");
        }
    }
}
