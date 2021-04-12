using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGames.Migrations
{
    public partial class IdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyColumnType: "nvarchar(450)",
                keyValue: "092ac723-015f-4b1e-9f9d-0029786bd978");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyColumnType: "nvarchar(450)",
                keyValue: "91f403aa-1e2e-4410-a605-b1bda1e486a9");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyColumnType: "nvarchar(450)",
                keyValue: "bcccb714-e036-4cd7-b02d-03c624c482a6");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyColumnType: "nvarchar(450)",
                keyValue: "dcbbd972-aea6-478e-a07d-8a6b328e6791");

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyColumnType: "nvarchar(450)",
                keyValue: "ed35547b-0f77-4001-8618-e03832558564");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "NewGames");

            migrationBuilder.AddColumn<long>(
                name: "GameId",
                table: "NewGames",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewGames",
                table: "NewGames",
                column: "GameId");

            migrationBuilder.InsertData(
                table: "NewGames",
                columns: new[] { "GameId", "Completed", "Genre", "Name" },
                values: new object[,]
                {
                    { -1L, false, "Action", "Batman Arkham Asylum" },
                    { -2L, false, "MMORPG", "Guild Wars 2" },
                    { -3L, true, "Shooter", "Halo" },
                    { -4L, false, "Shooter", "Call Of Duty 2" },
                    { -5L, true, "Shooter", "BioShock Infinite" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewGames",
                table: "NewGames");

            migrationBuilder.DeleteData(
                table: "NewGames",
                keyColumn: "GameId",
                keyColumnType: "bigint",
                keyValue: -5L);

            migrationBuilder.DeleteData(
                table: "NewGames",
                keyColumn: "GameId",
                keyColumnType: "bigint",
                keyValue: -4L);

            migrationBuilder.DeleteData(
                table: "NewGames",
                keyColumn: "GameId",
                keyColumnType: "bigint",
                keyValue: -3L);

            migrationBuilder.DeleteData(
                table: "NewGames",
                keyColumn: "GameId",
                keyColumnType: "bigint",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "NewGames",
                keyColumn: "GameId",
                keyColumnType: "bigint",
                keyValue: -1L);

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "NewGames");

            migrationBuilder.RenameTable(
                name: "NewGames",
                newName: "Games");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Games",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");

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
    }
}
