using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace L3C1WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3489eee2-e301-47a4-93d1-632894187ab7", "923da883-139e-4c82-8d16-50e119de0c80", "Admin", "ADMIN" },
                    { "7e1d6df1-aff7-4f9f-b805-123ff6bd09fe", "50e710b6-3d47-4cc5-8b3c-036f1172ebe3", "Student", "STUDENT" },
                    { "92667dc2-bc30-4cbb-a666-4ffb50f6238e", "b56e9c34-6560-4ade-8b9b-5265e7665cc9", "Instructor", "INSTRUCTOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3489eee2-e301-47a4-93d1-632894187ab7");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7e1d6df1-aff7-4f9f-b805-123ff6bd09fe");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "92667dc2-bc30-4cbb-a666-4ffb50f6238e");
        }
    }
}
