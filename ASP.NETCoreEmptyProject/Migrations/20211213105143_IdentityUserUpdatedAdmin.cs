using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreEmptyProject.Migrations
{
    public partial class IdentityUserUpdatedAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "631f56eb-851d-45a5-a2c6-aac243323b83", "cf23e59e-8b60-4080-abdc-deac80d39d94", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0cdb0046-32ca-4329-aa89-1f56a572b6f5", "6883069a-292d-4ee9-bba7-3f3ae37f4f16", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cf837a14-c0fc-479e-9542-9e7693e801cb", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "4d4418d3-db38-4723-85d4-ab1dd07af690", "admin@admin.com", false, "Admin", "Adminsson", false, null, "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAEAACcQAAAAEFwdHpggig6D2vgtyt3+VVRYjpOPjL+ain7G953fqucGUikhutQMh1HJI5G/NhT5xw==", null, false, "ee90ebb5-345b-455c-87f0-fcc86606560b", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "cf837a14-c0fc-479e-9542-9e7693e801cb", "631f56eb-851d-45a5-a2c6-aac243323b83" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0cdb0046-32ca-4329-aa89-1f56a572b6f5");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "cf837a14-c0fc-479e-9542-9e7693e801cb", "631f56eb-851d-45a5-a2c6-aac243323b83" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "631f56eb-851d-45a5-a2c6-aac243323b83");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cf837a14-c0fc-479e-9542-9e7693e801cb");
        }
    }
}
