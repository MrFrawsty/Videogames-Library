using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations.VideoGames
{
    public partial class test2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_VideoGamesUserId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "VideoGamesUserId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_VideoGamesUserId",
                table: "Games",
                column: "VideoGamesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_VideoGamesUserId",
                table: "Games");

            migrationBuilder.AlterColumn<string>(
                name: "VideoGamesUserId",
                table: "Games",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_VideoGamesUserId",
                table: "Games",
                column: "VideoGamesUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
