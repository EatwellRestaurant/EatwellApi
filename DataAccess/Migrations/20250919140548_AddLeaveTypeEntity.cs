using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddLeaveTypeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YearLeaveRight_LeaveRights_LeaveRightId",
                table: "YearLeaveRight");

            migrationBuilder.DropForeignKey(
                name: "FK_YearLeaveRight_Years_YearId",
                table: "YearLeaveRight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearLeaveRight",
                table: "YearLeaveRight");

            migrationBuilder.DropColumn(
                name: "LeaveType",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LeaveRights");

            migrationBuilder.RenameTable(
                name: "YearLeaveRight",
                newName: "YearLeaveRights");

            migrationBuilder.RenameIndex(
                name: "IX_YearLeaveRight_LeaveRightId",
                table: "YearLeaveRights",
                newName: "IX_YearLeaveRights_LeaveRightId");

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "Permissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeaveTypeId",
                table: "LeaveRights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SeniorityRange",
                table: "LeaveRights",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "YearId",
                table: "LeaveRights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearLeaveRights",
                table: "YearLeaveRights",
                columns: new[] { "YearId", "LeaveRightId" });

            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "LeaveTypeId", "SeniorityRange", "YearId" },
                values: new object[] { 1, "0-1", 1 });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LeaveTypeId", "SeniorityRange", "YearId" },
                values: new object[] { 1, "5-15", 1 });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "LeaveTypeId", "SeniorityRange", "YearId" },
                values: new object[] { 1, "15", 1 });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DayCount", "LeaveTypeId", "SeniorityRange", "YearId" },
                values: new object[] { (byte)5, 2, "*", 1 });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DayCount", "LeaveTypeId", "SeniorityRange", "YearId" },
                values: new object[] { (byte)30, 3, "*", 1 });

            migrationBuilder.InsertData(
                table: "LeaveRights",
                columns: new[] { "Id", "DayCount", "LeaveTypeId", "SeniorityRange", "YearId" },
                values: new object[,]
                {
                    { 6, (byte)10, 4, "*", 1 },
                    { 7, (byte)112, 5, "*", 1 },
                    { 8, (byte)5, 6, "*", 1 },
                    { 9, (byte)3, 7, "*", 1 },
                    { 10, (byte)5, 8, "*", 1 }
                });

            migrationBuilder.InsertData(
                table: "LeaveTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Yıllık İzin" },
                    { 2, "Mazeret İzni" },
                    { 3, "Ücretsiz İzin" },
                    { 4, "Hastalık İzni" },
                    { 5, "Doğum İzni" },
                    { 6, "Babalık İzni" },
                    { 7, "Evlilik İzni" },
                    { 8, "Cenaze İzni" }
                });

            migrationBuilder.InsertData(
                table: "Years",
                columns: new[] { "Id", "DeleteDate", "Name", "UpdateDate" },
                values: new object[] { 2, null, "2025", null });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_LeaveTypeId",
                table: "Permissions",
                column: "LeaveTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_LeaveTypes_LeaveTypeId",
                table: "Permissions",
                column: "LeaveTypeId",
                principalTable: "LeaveTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YearLeaveRights_LeaveRights_LeaveRightId",
                table: "YearLeaveRights",
                column: "LeaveRightId",
                principalTable: "LeaveRights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YearLeaveRights_Years_YearId",
                table: "YearLeaveRights",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_LeaveTypes_LeaveTypeId",
                table: "Permissions");

            migrationBuilder.DropForeignKey(
                name: "FK_YearLeaveRights_LeaveRights_LeaveRightId",
                table: "YearLeaveRights");

            migrationBuilder.DropForeignKey(
                name: "FK_YearLeaveRights_Years_YearId",
                table: "YearLeaveRights");

            migrationBuilder.DropTable(
                name: "LeaveTypes");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_LeaveTypeId",
                table: "Permissions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_YearLeaveRights",
                table: "YearLeaveRights");

            migrationBuilder.DeleteData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Years",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "LeaveTypeId",
                table: "LeaveRights");

            migrationBuilder.DropColumn(
                name: "SeniorityRange",
                table: "LeaveRights");

            migrationBuilder.DropColumn(
                name: "YearId",
                table: "LeaveRights");

            migrationBuilder.RenameTable(
                name: "YearLeaveRights",
                newName: "YearLeaveRight");

            migrationBuilder.RenameIndex(
                name: "IX_YearLeaveRights_LeaveRightId",
                table: "YearLeaveRight",
                newName: "IX_YearLeaveRight_LeaveRightId");

            migrationBuilder.AddColumn<byte>(
                name: "LeaveType",
                table: "Permissions",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LeaveRights",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_YearLeaveRight",
                table: "YearLeaveRight",
                columns: new[] { "YearId", "LeaveRightId" });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Yıllık İzin (Yeni başlayan)");

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Yıllık İzin (1-5 yıl kıdem)");

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Yıllık İzin (5+ yıl kıdem)");

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "DayCount", "Name" },
                values: new object[] { (byte)10, "Hastalık İzni" });

            migrationBuilder.UpdateData(
                table: "LeaveRights",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "DayCount", "Name" },
                values: new object[] { (byte)5, "Mazeret İzni" });

            migrationBuilder.AddForeignKey(
                name: "FK_YearLeaveRight_LeaveRights_LeaveRightId",
                table: "YearLeaveRight",
                column: "LeaveRightId",
                principalTable: "LeaveRights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_YearLeaveRight_Years_YearId",
                table: "YearLeaveRight",
                column: "YearId",
                principalTable: "Years",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
