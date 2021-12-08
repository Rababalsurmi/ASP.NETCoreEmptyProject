using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class PeopleDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(maxLength: 10, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CountryName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(maxLength: 10, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<int>(maxLength: 10, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CityName = table.Column<string>(nullable: false),
                    CurrentCountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_City_Country_CurrentCountryId",
                        column: x => x.CurrentCountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CountryCityModel",
                columns: table => new
                {
                    CountryId = table.Column<int>(maxLength: 10, nullable: false),
                    CityId = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryCityModel", x => new { x.CountryId, x.CityId });
                    table.ForeignKey(
                        name: "FK_CountryCityModel_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CountryCityModel_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 10, nullable: false, defaultValue: 0),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<int>(maxLength: 10, nullable: false),
                    CurrentCityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_City_CurrentCityId",
                        column: x => x.CurrentCityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleCityModel",
                columns: table => new
                {
                    PersonId = table.Column<int>(maxLength: 10, nullable: false),
                    CityId = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleCityModel", x => new { x.PersonId, x.CityId });
                    table.ForeignKey(
                        name: "FK_PeopleCityModel_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleCityModel_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleLanguages",
                columns: table => new
                {
                    PersonId = table.Column<int>(maxLength: 10, nullable: false),
                    LanguageId = table.Column<int>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleLanguages", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PeopleLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleLanguages_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Sweden" },
                    { 2, "Germany" },
                    { 3, "Norway" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "LanguageId", "Language" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 2, "German" },
                    { 3, "Norwegian" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "CurrentCountryId" },
                values: new object[] { 1, "Stockholm", 1 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "CurrentCountryId" },
                values: new object[] { 2, "Frankfurt", 2 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityId", "CityName", "CurrentCountryId" },
                values: new object[] { 3, "Oslo", 3 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CurrentCityId", "Name", "Phone" },
                values: new object[] { 1, 1, "Tom", 712345678 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CurrentCityId", "Name", "Phone" },
                values: new object[] { 2, 2, "John", 712345678 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "CurrentCityId", "Name", "Phone" },
                values: new object[] { 3, 3, "Jonas", 712345678 });

            migrationBuilder.InsertData(
                table: "PeopleLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CurrentCountryId",
                table: "City",
                column: "CurrentCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CountryCityModel_CityId",
                table: "CountryCityModel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CurrentCityId",
                table: "People",
                column: "CurrentCityId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCityModel_CityId",
                table: "PeopleCityModel",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleLanguages_LanguageId",
                table: "PeopleLanguages",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCityModel");

            migrationBuilder.DropTable(
                name: "PeopleCityModel");

            migrationBuilder.DropTable(
                name: "PeopleLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
