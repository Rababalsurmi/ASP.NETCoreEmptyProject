using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class PeopleDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityName);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryName);
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

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 10, nullable: false, defaultValue: 0),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(maxLength: 10, nullable: false),
                    City = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryCity",
                columns: table => new
                {
                    CountryName = table.Column<string>(nullable: false),
                    CityName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCity", x => new { x.CountryName, x.CityName });
                    table.ForeignKey(
                        name: "FK_CountryCity_City_CityName",
                        column: x => x.CityName,
                        principalTable: "City",
                        principalColumn: "CityName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCity_Country_CountryName",
                        column: x => x.CountryName,
                        principalTable: "Country",
                        principalColumn: "CountryName",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleCity",
                columns: table => new
                {
                    PersonId = table.Column<int>(maxLength: 10, nullable: false),
                    CityName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleCity", x => new { x.PersonId, x.CityName });
                    table.ForeignKey(
                        name: "FK_PeopleCity_City_CityName",
                        column: x => x.CityName,
                        principalTable: "City",
                        principalColumn: "CityName",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleCity_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "City",
                column: "CityName",
                values: new object[]
                {
                    "Stockholm",
                    "Frankfurt",
                    "Oslo"
                });

            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
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

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Skövde", "Tom", 712345678 },
                    { 2, "Kungälv", "John", 712345678 },
                    { 3, "Göteborg", "Jonas", 712345678 }
                });

            migrationBuilder.InsertData(
                table: "CountryCity",
                columns: new[] { "CountryName", "CityName" },
                values: new object[,]
                {
                    { "Sweden", "Stockholm" },
                    { "Germany", "Frankfurt" },
                    { "Norway", "Oslo" }
                });

            migrationBuilder.InsertData(
                table: "PeopleCity",
                columns: new[] { "PersonId", "CityName" },
                values: new object[,]
                {
                    { 1, "Stockholm" },
                    { 2, "Frankfurt" },
                    { 3, "Oslo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CountryCity_CityName",
                table: "CountryCity",
                column: "CityName");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCity_CityName",
                table: "PeopleCity",
                column: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCity");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "PeopleCity");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
