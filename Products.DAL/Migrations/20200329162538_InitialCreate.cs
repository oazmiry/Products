using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Products.DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sellers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: false),
                    SellerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Sellers_SellerId",
                        column: x => x.SellerId,
                        principalTable: "Sellers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Items_SellerId",
                table: "Items",
                column: "SellerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Sellers");
        }
    }
}
