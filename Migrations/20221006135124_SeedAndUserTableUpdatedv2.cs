using Microsoft.EntityFrameworkCore.Migrations;

namespace QuotationMgmtSystem.Migrations
{
    public partial class SeedAndUserTableUpdatedv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Role",
                value: "Administrator");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3,
                column: "Role",
                value: "Admin");
        }
    }
}
