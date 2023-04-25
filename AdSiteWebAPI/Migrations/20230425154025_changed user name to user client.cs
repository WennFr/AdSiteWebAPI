using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdSiteWebAPI.Migrations
{
    public partial class changedusernametouserclient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Users_UserId",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Bids",
                newName: "UserClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_UserId",
                table: "Bids",
                newName: "IX_Bids_UserClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Users_UserClientId",
                table: "Bids",
                column: "UserClientId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Users_UserClientId",
                table: "Bids");

            migrationBuilder.RenameColumn(
                name: "UserClientId",
                table: "Bids",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Bids_UserClientId",
                table: "Bids",
                newName: "IX_Bids_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Users_UserId",
                table: "Bids",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
