using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EatwellApi.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DropOperationClaimIdFromEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_OperationClaims_OperationClaimId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_OperationClaimId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "OperationClaimId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OperationClaimId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_OperationClaimId",
                table: "Employees",
                column: "OperationClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_OperationClaims_OperationClaimId",
                table: "Employees",
                column: "OperationClaimId",
                principalTable: "OperationClaims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
