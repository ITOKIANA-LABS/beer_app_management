using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace beer_app_management.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "113f54dd-6884-48d6-977d-abd774242a23", null, "Brewer", "BREWER" },
                    { "8c65408b-637f-48e6-a84e-624fe96e4013", null, "Admin", "ADMIN" },
                    { "e39c7410-fd4a-437f-bf04-929c9d5609ef", null, "Wholesaler", "WHOLESALER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "113f54dd-6884-48d6-977d-abd774242a23");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c65408b-637f-48e6-a84e-624fe96e4013");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e39c7410-fd4a-437f-bf04-929c9d5609ef");
        }
    }
}
