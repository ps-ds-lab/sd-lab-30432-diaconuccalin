using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class InsertedRoles3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IdentityRole");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "IdentityRole",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityRole", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cbc6c9e7-4055-418f-8da7-1c73f0e356c7", "a07f7c64-3037-494e-8d74-d2036fef5ffc", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "49c2375e-ce87-4de4-965c-f3858f03788d", "8a1de8ce-cfbd-4838-bdba-fe9f4cece557", "Guest", "GUEST" });

            migrationBuilder.InsertData(
                table: "IdentityRole",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "13fd909f-13ce-4468-87ff-b0e2b395cbb5", "f4212b10-7890-4bd8-b830-07aa5cef8c88", "Host", "HOST" });
        }
    }
}
