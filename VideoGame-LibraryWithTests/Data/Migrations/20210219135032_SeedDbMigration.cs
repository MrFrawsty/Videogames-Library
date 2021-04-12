using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class SeedDbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "b23b62ab-f69c-437b-9ace-4e515cb658f0", true, "RPG", "TorchLight 2" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "4fae2c9a-6b70-4fcc-8821-e6801cc16d38", false, "Looter Shooter", "Borderlands 3" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "9fc71bd6-bbeb-463f-88ee-aa756a7e83b8", true, "Shooter", "Gears Of War 3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "4fae2c9a-6b70-4fcc-8821-e6801cc16d38");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "9fc71bd6-bbeb-463f-88ee-aa756a7e83b8");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "b23b62ab-f69c-437b-9ace-4e515cb658f0");
        }
    }
}
