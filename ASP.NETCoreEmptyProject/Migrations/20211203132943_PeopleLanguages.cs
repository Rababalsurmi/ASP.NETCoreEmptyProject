using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class PeopleLanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Language",
                table: "Language");

            migrationBuilder.RenameTable(
                name: "Language",
                newName: "Languages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Languages",
                table: "Languages",
                column: "Language");

            migrationBuilder.CreateTable(
                name: "PeopleLanguages",
                columns: table => new
                {
                    PersonId = table.Column<int>(maxLength: 10, nullable: false),
                    Language = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleLanguages", x => new { x.PersonId, x.Language });
                    table.ForeignKey(
                        name: "FK_PeopleLanguages_Languages_Language",
                        column: x => x.Language,
                        principalTable: "Languages",
                        principalColumn: "Language",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeopleLanguages_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PeopleLanguages",
                columns: new[] { "PersonId", "Language" },
                values: new object[,]
                {
                    { 1, "English" },
                    { 1, "Norwegian" },
                    { 3, "English" },
                    { 3, "German" },
                    { 2, "Norwegian" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleLanguages_Language",
                table: "PeopleLanguages",
                column: "Language");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeopleLanguages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Languages",
                table: "Languages");

            migrationBuilder.RenameTable(
                name: "Languages",
                newName: "Language");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Language",
                table: "Language",
                column: "Language");
        }
    }
}
