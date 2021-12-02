using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class SeededData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "People",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "People",
                maxLength: 10,
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 10)
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "Phone" },
                values: new object[] { 1, "Skövde", "Tom", 712345678 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "Phone" },
                values: new object[] { 2, "Kungälv", "John", 712345678 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "City", "Name", "Phone" },
                values: new object[] { 3, "Göteborg", "Jonas", 712345678 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "People",
                newName: "PersonId");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "People",
                type: "int",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldMaxLength: 10,
                oldDefaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);
        }
    }
}
