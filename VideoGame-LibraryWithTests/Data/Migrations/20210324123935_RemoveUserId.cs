using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class RemoveUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "NewGames");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "NewGames",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
