using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddBranchIdAndTableNoColumnToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "Tables",
                type: "int",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "TableNo",
                table: "Tables",
                type: "int",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Tables_BranchId",
                table: "Tables",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tables_Branches_BranchId",
                table: "Tables",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tables_Branches_BranchId",
                table: "Tables");

            migrationBuilder.DropIndex(
                name: "IX_Tables_BranchId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "Tables");

            migrationBuilder.DropColumn(
                name: "TableNo",
                table: "Tables");
        }
    }
}
