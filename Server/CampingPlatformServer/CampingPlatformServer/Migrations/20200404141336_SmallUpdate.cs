using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class SmallUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "CorrespondingId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86b2b2fa-460c-4d59-9cb0-13290ab1f19e", "68345385-df11-4f9b-9394-8b091c816ff9", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2196c733-165f-4336-9fc1-988f78412a9b", "71e0ec70-87a9-447f-a62f-03e08b3b5fab", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e2cf2e0d-6c08-4665-bea5-f88eaa81d3f5", "1075bbf3-2d3c-4eb0-9e31-2c855577833b", "Host", "HOST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2196c733-165f-4336-9fc1-988f78412a9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86b2b2fa-460c-4d59-9cb0-13290ab1f19e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e2cf2e0d-6c08-4665-bea5-f88eaa81d3f5");

            migrationBuilder.DropColumn(
                name: "CorrespondingId",
                table: "AspNetUsers");

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
    }
}
