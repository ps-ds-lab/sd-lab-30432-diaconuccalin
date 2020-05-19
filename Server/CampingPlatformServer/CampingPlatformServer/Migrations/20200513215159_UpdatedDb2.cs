using Microsoft.EntityFrameworkCore.Migrations;

namespace CampingPlatformServer.Migrations
{
    public partial class UpdatedDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Host_HostId",
                table: "Location");

            migrationBuilder.DropIndex(
                name: "IX_Location_HostId",
                table: "Location");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Location_HostId",
                table: "Location",
                column: "HostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Host_HostId",
                table: "Location",
                column: "HostId",
                principalTable: "Host",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
