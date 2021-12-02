using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class CountryCityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Country",
                keyValue: "Germany");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Country",
                keyValue: "Norway");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "Country",
                keyValue: "Sweden");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Country");

            migrationBuilder.AddColumn<string>(
                name: "CountryName",
                table: "Country",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryName");

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

            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
                value: "Sweden");

            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
                value: "Germany");

            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
                value: "Norway");

            migrationBuilder.InsertData(
                table: "CountryCity",
                columns: new[] { "CountryName", "CityName" },
                values: new object[] { "Sweden", "Stockholm" });

            migrationBuilder.InsertData(
                table: "CountryCity",
                columns: new[] { "CountryName", "CityName" },
                values: new object[] { "Germany", "Frankfurt" });

            migrationBuilder.InsertData(
                table: "CountryCity",
                columns: new[] { "CountryName", "CityName" },
                values: new object[] { "Norway", "Oslo" });

            migrationBuilder.CreateIndex(
                name: "IX_CountryCity_CityName",
                table: "CountryCity",
                column: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CountryCity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Germany");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Norway");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Sweden");

            migrationBuilder.DropColumn(
                name: "CountryName",
                table: "Country");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Country",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "Country");

            migrationBuilder.InsertData(
                table: "Country",
                column: "Country",
                value: "Sweden");

            migrationBuilder.InsertData(
                table: "Country",
                column: "Country",
                value: "Germany");

            migrationBuilder.InsertData(
                table: "Country",
                column: "Country",
                value: "Norway");
        }
    }
}
