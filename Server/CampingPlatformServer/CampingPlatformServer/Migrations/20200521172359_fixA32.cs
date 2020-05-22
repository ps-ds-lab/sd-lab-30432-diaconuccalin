using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class fixA32 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GuestRequest_Guest_GuestId",
                table: "GuestRequest");

            migrationBuilder.DropIndex(
                name: "IX_GuestRequest_GuestId",
                table: "GuestRequest");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_GuestRequest_GuestId",
                table: "GuestRequest",
                column: "GuestId");

            migrationBuilder.AddForeignKey(
                name: "FK_GuestRequest_Guest_GuestId",
                table: "GuestRequest",
                column: "GuestId",
                principalTable: "Guest",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
