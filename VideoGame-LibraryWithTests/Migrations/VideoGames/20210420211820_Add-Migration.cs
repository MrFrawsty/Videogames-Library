using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations.VideoGames
{
    public partial class AddMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
