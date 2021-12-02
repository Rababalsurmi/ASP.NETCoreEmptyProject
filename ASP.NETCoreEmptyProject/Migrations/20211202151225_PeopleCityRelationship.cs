using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class PeopleCityRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "City",
                keyValue: "Frankfurt");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "City",
                keyValue: "Oslo");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "City",
                keyValue: "Stockholm");

            migrationBuilder.DropColumn(
                name: "City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "CityNum",
                table: "City");

            migrationBuilder.AddColumn<string>(
                name: "CityName",
                table: "City",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "CityName");

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
                value: "Stockholm");

            migrationBuilder.InsertData(
                table: "City",
                column: "CityName",
                value: "Frankfurt");

            migrationBuilder.InsertData(
                table: "City",
                column: "CityName",
                value: "Oslo");

            migrationBuilder.InsertData(
                table: "PeopleCity",
                columns: new[] { "PersonId", "CityName" },
                values: new object[] { 1, "Stockholm" });

            migrationBuilder.InsertData(
                table: "PeopleCity",
                columns: new[] { "PersonId", "CityName" },
                values: new object[] { 2, "Frankfurt" });

            migrationBuilder.InsertData(
                table: "PeopleCity",
                columns: new[] { "PersonId", "CityName" },
                values: new object[] { 3, "Oslo" });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleCity_CityName",
                table: "PeopleCity",
                column: "CityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleCity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Frankfurt");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Oslo");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Stockholm");

            migrationBuilder.DropColumn(
                name: "CityName",
                table: "City");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "City",
                type: "varchar(255) CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CityNum",
                table: "City",
                type: "int",
                maxLength: 6,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "City");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "City", "CityNum" },
                values: new object[] { "Stockholm", 0 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "City", "CityNum" },
                values: new object[] { "Frankfurt", 0 });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "City", "CityNum" },
                values: new object[] { "Oslo", 0 });
        }
    }
}
