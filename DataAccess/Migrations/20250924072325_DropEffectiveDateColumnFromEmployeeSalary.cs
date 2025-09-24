using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DropEffectiveDateColumnFromEmployeeSalary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EffectiveDate",
                table: "EmployeeSalaries");

            migrationBuilder.AddColumn<byte>(
                name: "Month",
                table: "EmployeeSalaries",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                table: "EmployeeSalaries",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeSalary_Month",
                table: "EmployeeSalaries",
                sql: "[Month] >= 1 AND [Month] <= 12");

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeSalary_Year",
                table: "EmployeeSalaries",
                sql: "[Year] >= 1900 AND [Year] <= 2100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeDeduction_Month",
                table: "EmployeeDeductions",
                sql: "[Month] >= 1 AND [Month] <= 12");

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeDeduction_Year",
                table: "EmployeeDeductions",
                sql: "[Year] >= 1900 AND [Year] <= 2100");

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeBonus_Month",
                table: "EmployeeBonuses",
                sql: "[Month] >= 1 AND [Month] <= 12");

            migrationBuilder.AddCheckConstraint(
                name: "CK_EmployeeBonus_Year",
                table: "EmployeeBonuses",
                sql: "[Year] >= 1900 AND [Year] <= 2100");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeSalary_Month",
                table: "EmployeeSalaries");

            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeSalary_Year",
                table: "EmployeeSalaries");

            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeDeduction_Month",
                table: "EmployeeDeductions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeDeduction_Year",
                table: "EmployeeDeductions");

            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeBonus_Month",
                table: "EmployeeBonuses");

            migrationBuilder.DropCheckConstraint(
                name: "CK_EmployeeBonus_Year",
                table: "EmployeeBonuses");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "EmployeeSalaries");
        }
    }
}
