using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AdSiteWebAPI.Migrations
{
    public partial class nullablepicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Pictures_PictureId",
                table: "Adverts");

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                table: "Adverts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Pictures_PictureId",
                table: "Adverts",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Pictures_PictureId",
                table: "Adverts");

            migrationBuilder.AlterColumn<int>(
                name: "PictureId",
                table: "Adverts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Pictures_PictureId",
                table: "Adverts",
                column: "PictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
