using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

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

            migrationBuilder.DeleteData(
                table: "Guest",
                keyColumn: "Id",
                keyValue: new Guid("99117ce4-f509-4f25-9213-08a1eb11cbd1"));

            migrationBuilder.DeleteData(
                table: "Host",
                keyColumn: "Id",
                keyValue: new Guid("6b4b958d-ea5c-4541-80f4-91e3779fb46a"));

            migrationBuilder.DeleteData(
                table: "Host",
                keyColumn: "Id",
                keyValue: new Guid("82e203d2-8dfc-408c-81fd-06ce41db478e"));

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Host");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Guest");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Guest");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f730ec3e-f659-43b2-ac54-385b9e40536f", "070a01c5-1415-46ab-8d5e-c235fd1305f4", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "53dfb935-802b-4245-a1d0-4d352512de7f", "34458ffb-a86a-40ce-8364-fe3341002a38", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fb0357c6-98f2-4fd3-b649-ecc7efa39167", "fbf36307-4f91-4517-882a-9ecd8904e2ad", "Host", "HOST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53dfb935-802b-4245-a1d0-4d352512de7f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f730ec3e-f659-43b2-ac54-385b9e40536f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fb0357c6-98f2-4fd3-b649-ecc7efa39167");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Host",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Host",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Host",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Host",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Guest",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Guest",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Guest",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Guest",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("8db91ddd-1192-441a-8960-de2dc68704df"), "securePassword", "greatAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "86b2b2fa-460c-4d59-9cb0-13290ab1f19e", "68345385-df11-4f9b-9394-8b091c816ff9", "Administrator", "ADMINISTRATOR" },
                    { "2196c733-165f-4336-9fc1-988f78412a9b", "71e0ec70-87a9-447f-a62f-03e08b3b5fab", "Guest", "GUEST" },
                    { "e2cf2e0d-6c08-4665-bea5-f88eaa81d3f5", "1075bbf3-2d3c-4eb0-9e31-2c855577833b", "Host", "HOST" }
                });

            migrationBuilder.InsertData(
                table: "Guest",
                columns: new[] { "Id", "DateOfBirth", "Description", "Email", "FirstName", "LastName", "Password", "ProfilePictureLocation", "TelephoneNumber", "Username" },
                values: new object[] { new Guid("99117ce4-f509-4f25-9213-08a1eb11cbd1"), new DateTime(1975, 10, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "user@one.com", "User", "One", "Password1", null, "+40749635568", "User1" });

            migrationBuilder.InsertData(
                table: "Host",
                columns: new[] { "Id", "DateOfBirth", "Email", "FirstName", "LastName", "Password", "ProfilePictureLocation", "TelephoneNumber", "Username" },
                values: new object[,]
                {
                    { new Guid("82e203d2-8dfc-408c-81fd-06ce41db478e"), new DateTime(1992, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "another.user@two.com", "Another User", "Two", "Password2", null, "+40749865768", "User2" },
                    { new Guid("6b4b958d-ea5c-4541-80f4-91e3779fb46a"), new DateTime(1963, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "lastUser@three.com", "Last User", "Three", "Password3", null, "+40749896568", "User3" }
                });
        }
    }
}
