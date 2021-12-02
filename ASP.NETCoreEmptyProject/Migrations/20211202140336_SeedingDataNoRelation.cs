using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class SeedingDataNoRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    City = table.Column<string>(nullable: false),
                    CityNum = table.Column<int>(maxLength: 6, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.City);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Country = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Country);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Language);
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "City", "CityNum" },
                values: new object[,]
                {
                    { "Stockholm", 0 },
                    { "Frankfurt", 0 },
                    { "Oslo", 0 }
                });

            migrationBuilder.InsertData(
                table: "Country",
                column: "Country",
                values: new object[]
                {
                    "Sweden",
                    "Germany",
                    "Norway"
                });

            migrationBuilder.InsertData(
                table: "Language",
                column: "Language",
                values: new object[]
                {
                    "English",
                    "German",
                    "Norwegian"
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
