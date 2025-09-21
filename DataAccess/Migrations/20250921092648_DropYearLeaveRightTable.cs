using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DropYearLeaveRightTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearLeaveRights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "YearLeaveRights",
                columns: table => new
                {
                    YearId = table.Column<int>(type: "int", nullable: false),
                    LeaveRightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearLeaveRights", x => new { x.YearId, x.LeaveRightId });
                    table.ForeignKey(
                        name: "FK_YearLeaveRights_LeaveRights_LeaveRightId",
                        column: x => x.LeaveRightId,
                        principalTable: "LeaveRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YearLeaveRights_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearLeaveRights_LeaveRightId",
                table: "YearLeaveRights",
                column: "LeaveRightId");
        }
    }
}
