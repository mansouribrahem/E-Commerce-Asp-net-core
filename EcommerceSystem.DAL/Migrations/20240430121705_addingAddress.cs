using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addingAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d131c8e-a746-46b6-a06c-c6b9e9c634c0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "73cd3f3e-0354-471c-ab2a-6654f3bf042c");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2626085f-757c-4c89-9bb4-96c17bd819c5", "b3648642-cef8-48eb-ad57-409a5e21baa5", "Admin", "ADMIN" },
                    { "5072dbe5-991b-4f43-bc78-f67556d6ceb4", "6ae1adde-d3f7-4908-be0b-c9aef2e0219f", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2626085f-757c-4c89-9bb4-96c17bd819c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5072dbe5-991b-4f43-bc78-f67556d6ceb4");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1d131c8e-a746-46b6-a06c-c6b9e9c634c0", "c783137a-fa09-4ea3-9b5a-6cdcc0e14d79", "Admin", "ADMIN" },
                    { "73cd3f3e-0354-471c-ab2a-6654f3bf042c", "6dabee9e-a582-4aaf-8808-3e7c5ce97749", "User", "USER" }
                });
        }
    }
}
