using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "262a5042-0604-4d17-9930-157394afed0a", "b74d8b2a-bcde-485e-aed7-256f5f4f10af", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d01c6677-c7e7-4386-9b02-60cff89d374a", "77f401cf-4a46-4ef2-9f6e-8e7a3960adac", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "33660800-aff6-42f8-bdd8-5eb4f9d17fd7", "c59d4df8-9eda-46d8-92ce-c5c5072322be", "Host", "HOST" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");
        }
    }
}
