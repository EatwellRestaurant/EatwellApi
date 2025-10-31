using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddMonthEntityAndRefactorEmployeeFinancials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Month",
                table: "EmployeeDeductions");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "EmployeeDeductions");

            migrationBuilder.DropColumn(
                name: "Month",
                table: "EmployeeBonuses");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "EmployeeBonuses");

            migrationBuilder.AddColumn<int>(
                name: "MonthId",
                table: "EmployeeSalaries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonthId",
                table: "EmployeeDeductions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MonthId",
                table: "EmployeeBonuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Months",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2025, 9, 24, 17, 57, 59, 812, DateTimeKind.Local).AddTicks(5202)),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    YearId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Months", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Months_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Months",
                columns: new[] { "Id", "DeleteDate", "Name", "UpdateDate", "YearId" },
                values: new object[,]
                {
                    { 10, null, "Ocak", null, 2 },
                    { 11, null, "Şubat", null, 2 },
                    { 12, null, "Mart", null, 2 },
                    { 13, null, "Nisan", null, 2 },
                    { 14, null, "Mayıs", null, 2 },
                    { 15, null, "Haziran", null, 2 },
                    { 16, null, "Temmuz", null, 2 },
                    { 17, null, "Ağustos", null, 2 },
                    { 18, null, "Eylül", null, 2 },
                    { 19, null, "Ekim", null, 2 },
                    { 20, null, "Kasım", null, 2 },
                    { 21, null, "Aralık", null, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeSalaries_MonthId",
                table: "EmployeeSalaries",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDeductions_MonthId",
                table: "EmployeeDeductions",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeBonuses_MonthId",
                table: "EmployeeBonuses",
                column: "MonthId");

            migrationBuilder.CreateIndex(
                name: "IX_Months_YearId",
                table: "Months",
                column: "YearId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeBonuses_Months_MonthId",
                table: "EmployeeBonuses",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDeductions_Months_MonthId",
                table: "EmployeeDeductions",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeSalaries_Months_MonthId",
                table: "EmployeeSalaries",
                column: "MonthId",
                principalTable: "Months",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeBonuses_Months_MonthId",
                table: "EmployeeBonuses");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDeductions_Months_MonthId",
                table: "EmployeeDeductions");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeSalaries_Months_MonthId",
                table: "EmployeeSalaries");

            migrationBuilder.DropTable(
                name: "Months");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeSalaries_MonthId",
                table: "EmployeeSalaries");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDeductions_MonthId",
                table: "EmployeeDeductions");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeBonuses_MonthId",
                table: "EmployeeBonuses");

            migrationBuilder.DropColumn(
                name: "MonthId",
                table: "EmployeeSalaries");

            migrationBuilder.DropColumn(
                name: "MonthId",
                table: "EmployeeDeductions");

            migrationBuilder.DropColumn(
                name: "MonthId",
                table: "EmployeeBonuses");

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

            migrationBuilder.AddColumn<byte>(
                name: "Month",
                table: "EmployeeDeductions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                table: "EmployeeDeductions",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "Month",
                table: "EmployeeBonuses",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Year",
                table: "EmployeeBonuses",
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
    }
}
