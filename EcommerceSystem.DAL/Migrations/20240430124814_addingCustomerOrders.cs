using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingCustomerOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2626085f-757c-4c89-9bb4-96c17bd819c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5072dbe5-991b-4f43-bc78-f67556d6ceb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "297db146-71b0-497f-8953-116de4d6f795", "6814d5d8-ff91-4aa5-af6b-03b97449c88d", "Admin", "ADMIN" },
                    { "d926ea7c-b65d-4cd6-95ca-9b7838452680", "8cf0f36b-1bd4-48eb-8573-566cffd3684d", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297db146-71b0-497f-8953-116de4d6f795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d926ea7c-b65d-4cd6-95ca-9b7838452680");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2626085f-757c-4c89-9bb4-96c17bd819c5", "b3648642-cef8-48eb-ad57-409a5e21baa5", "Admin", "ADMIN" },
                    { "5072dbe5-991b-4f43-bc78-f67556d6ceb4", "6ae1adde-d3f7-4908-be0b-c9aef2e0219f", "User", "USER" }
                });
        }
    }
}
