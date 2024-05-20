using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class userRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d131c8e-a746-46b6-a06c-c6b9e9c634c0", "c783137a-fa09-4ea3-9b5a-6cdcc0e14d79", "Admin", "ADMIN" },
                    { "73cd3f3e-0354-471c-ab2a-6654f3bf042c", "6dabee9e-a582-4aaf-8808-3e7c5ce97749", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d131c8e-a746-46b6-a06c-c6b9e9c634c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73cd3f3e-0354-471c-ab2a-6654f3bf042c");
        }
    }
}
