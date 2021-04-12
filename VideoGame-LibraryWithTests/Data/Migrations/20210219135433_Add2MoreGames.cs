using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class Add2MoreGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
