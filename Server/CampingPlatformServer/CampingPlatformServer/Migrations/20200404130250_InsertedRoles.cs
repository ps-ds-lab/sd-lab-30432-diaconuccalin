using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "01807995-d804-462e-b0d5-7c2aa183d8a6", "e04a6e30-30cb-4702-a108-f3756f6e514e", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c8cad7d5-75ef-4dc4-b9d4-6b2a403d29f4", "63e5f647-075d-4325-8c45-0bdc0030133d", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e1757bb-3cc2-4256-a6ef-4c035f31b4d0", "70933c63-de36-46a4-9e12-845f77275270", "Host", "HOST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "01807995-d804-462e-b0d5-7c2aa183d8a6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e1757bb-3cc2-4256-a6ef-4c035f31b4d0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8cad7d5-75ef-4dc4-b9d4-6b2a403d29f4");
        }
    }
}
