using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class InititialMigration21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Completed", "Genre", "Name" },
                values: new object[,]
                {
                    { "dcbbd972-aea6-478e-a07d-8a6b328e6791", false, "Action", "Batman Arkham Asylum" },
                    { "91f403aa-1e2e-4410-a605-b1bda1e486a9", false, "MMORPG", "Guild Wars 2" },
                    { "092ac723-015f-4b1e-9f9d-0029786bd978", true, "Shooter", "Halo" },
                    { "ed35547b-0f77-4001-8618-e03832558564", false, "Shooter", "Call Of Duty 2" },
                    { "bcccb714-e036-4cd7-b02d-03c624c482a6", true, "Shooter", "BioShock Infinite" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "092ac723-015f-4b1e-9f9d-0029786bd978");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "91f403aa-1e2e-4410-a605-b1bda1e486a9");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "bcccb714-e036-4cd7-b02d-03c624c482a6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "dcbbd972-aea6-478e-a07d-8a6b328e6791");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: "ed35547b-0f77-4001-8618-e03832558564");
        }
    }
}
