using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class MainMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    ProfilePictureLocation = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Host",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(maxLength: 60, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: false),
                    LastName = table.Column<string>(maxLength: 60, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    TelephoneNumber = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 60, nullable: false),
                    ProfilePictureLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Host", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HostId = table.Column<Guid>(nullable: false),
                    MaxNoGuests = table.Column<int>(nullable: false),
                    PhysicalAddress = table.Column<string>(maxLength: 200, nullable: false),
                    Description = table.Column<string>(maxLength: 400, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Host_HostId",
                        column: x => x.HostId,
                        principalTable: "Host",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GuestRequest",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GuestId = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuestRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GuestRequest_Guest_GuestId",
                        column: x => x.GuestId,
                        principalTable: "Guest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuestRequest_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationDate",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationDate_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocationImage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LocationId = table.Column<Guid>(nullable: false),
                    PictureLocation = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationImage_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[] { new Guid("8db91ddd-1192-441a-8960-de2dc68704df"), "securePassword", "greatAdmin" });

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

            migrationBuilder.CreateIndex(
                name: "IX_GuestRequest_GuestId",
                table: "GuestRequest",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_GuestRequest_LocationId",
                table: "GuestRequest",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_HostId",
                table: "Location",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationDate_LocationId",
                table: "LocationDate",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_LocationImage_LocationId",
                table: "LocationImage",
                column: "LocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "GuestRequest");

            migrationBuilder.DropTable(
                name: "LocationDate");

            migrationBuilder.DropTable(
                name: "LocationImage");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Host");
        }
    }
}
