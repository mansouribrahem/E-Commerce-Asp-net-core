using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceSystem.DAL.Migrations
{
    /// <inheritdoc />
    public partial class removingCustomerPass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "297db146-71b0-497f-8953-116de4d6f795");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d926ea7c-b65d-4cd6-95ca-9b7838452680");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Customers");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3c2c5d35-c587-4df9-b650-4c7207dd1a29", "494c29cb-a070-474c-bbed-890c0cff8f56", "User", "USER" },
                    { "dc6b4fe7-fd12-44d2-a43d-e45541f967a4", "eea3bde7-0f53-42b0-8848-0009d119f0ad", "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserName",
                table: "Customers",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_UserName",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3c2c5d35-c587-4df9-b650-4c7207dd1a29");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc6b4fe7-fd12-44d2-a43d-e45541f967a4");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "297db146-71b0-497f-8953-116de4d6f795", "6814d5d8-ff91-4aa5-af6b-03b97449c88d", "Admin", "ADMIN" },
                    { "d926ea7c-b65d-4cd6-95ca-9b7838452680", "8cf0f36b-1bd4-48eb-8573-566cffd3684d", "User", "USER" }
                });
        }
    }
}
