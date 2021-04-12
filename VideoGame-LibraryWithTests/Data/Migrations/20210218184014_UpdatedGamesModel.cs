using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class UpdatedGamesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "cc326c5f-a3ca-4261-887c-7c4744890565", true, "Shooter", "Bioshock" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "cc326c5f-a3ca-4261-887c-7c4744890565");
        }
    }
}
