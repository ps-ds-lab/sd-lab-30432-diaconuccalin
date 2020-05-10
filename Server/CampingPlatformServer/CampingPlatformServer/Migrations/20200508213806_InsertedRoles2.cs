using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class InsertedRoles2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "262a5042-0604-4d17-9930-157394afed0a");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "33660800-aff6-42f8-bdd8-5eb4f9d17fd7");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "d01c6677-c7e7-4386-9b02-60cff89d374a");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "13fd909f-13ce-4468-87ff-b0e2b395cbb5");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "49c2375e-ce87-4de4-965c-f3858f03788d");

            migrationBuilder.DeleteData(
                table: "IdentityRole",
                keyColumn: "Id",
                keyValue: "cbc6c9e7-4055-418f-8da7-1c73f0e356c7");

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
    }
}
