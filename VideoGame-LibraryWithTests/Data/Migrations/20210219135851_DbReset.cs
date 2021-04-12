using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class DbReset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "6e506d75-9b24-4947-ae67-fb2fa541cc4f");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "93ea35a4-f65a-4dcd-a1c7-fec3b8718d24");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "e82c3ebe-56b3-4f09-a671-a93b5b79a1eb");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "e82c3ebe-56b3-4f09-a671-a93b5b79a1eb", true, "RPG", "TorchLight 2" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "93ea35a4-f65a-4dcd-a1c7-fec3b8718d24", false, "Looter Shooter", "Borderlands 3" });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[] { "6e506d75-9b24-4947-ae67-fb2fa541cc4f", true, "Shooter", "Gears Of War 3" });
        }
    }
}
