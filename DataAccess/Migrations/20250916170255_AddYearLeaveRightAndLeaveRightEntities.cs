using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddYearLeaveRightAndLeaveRightEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveRights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: false),
                    DayCount = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearLeaveRight",
                columns: table => new
                {
                    YearId = table.Column<int>(type: "int", nullable: false),
                    LeaveRightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearLeaveRight", x => new { x.YearId, x.LeaveRightId });
                    table.ForeignKey(
                        name: "FK_YearLeaveRight_LeaveRights_LeaveRightId",
                        column: x => x.LeaveRightId,
                        principalTable: "LeaveRights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_YearLeaveRight_Years_YearId",
                        column: x => x.YearId,
                        principalTable: "Years",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "LeaveRights",
                columns: new[] { "Id", "DayCount", "Name" },
                values: new object[,]
                {
                    { 1, (byte)14, "Yıllık İzin (Yeni başlayan)" },
                    { 2, (byte)20, "Yıllık İzin (1-5 yıl kıdem)" },
                    { 3, (byte)26, "Yıllık İzin (5+ yıl kıdem)" },
                    { 4, (byte)10, "Hastalık İzni" },
                    { 5, (byte)5, "Mazeret İzni" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearLeaveRight_LeaveRightId",
                table: "YearLeaveRight",
                column: "LeaveRightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearLeaveRight");

            migrationBuilder.DropTable(
                name: "LeaveRights");
        }
    }
}
