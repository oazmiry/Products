using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "Id",
                keyValue: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Me" });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Him" });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "SellerId" },
                values: new object[] { 1, "My first thing", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "SellerId" },
                values: new object[] { 2, "My second thing", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "SellerId" },
                values: new object[] { 3, "His only thing", 2 });
        }
    }
}
