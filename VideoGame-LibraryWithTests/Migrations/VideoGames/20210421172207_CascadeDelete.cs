using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations.VideoGames
{
    public partial class CascadeDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_VideoGamesUserId",
                table: "Games");

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
