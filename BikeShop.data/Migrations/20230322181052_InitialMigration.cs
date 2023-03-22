using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shoppingBags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingBags_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shoppingItems_shoppingBags_ShoppingBagId",
                        column: x => x.ShoppingBagId,
                        principalTable: "shoppingBags",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "customers",
                columns: new[] { "Id", "FirstName", "Name" },
                values: new object[] { 1, "Dries", "Yperman" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Specialized", 2048m },
                    { 2, "Specialized", 511m },
                    { 3, "Pinarello", 1581m },
                    { 4, "Trek", 1965m },
                    { 5, "Specialized", 3993m },
                    { 6, "Specialized", 4620m },
                    { 7, "Cannondale", 4782m },
                    { 8, "Cervelo", 2286m },
                    { 9, "Scott", 3307m },
                    { 10, "Giant", 1063m },
                    { 11, "Giant", 3736m },
                    { 12, "Pinarello", 668m },
                    { 13, "Specialized", 3285m },
                    { 14, "Specialized", 4368m },
                    { 15, "Giant", 3487m },
                    { 16, "Cannondale", 3651m },
                    { 17, "Bianchi", 3477m },
                    { 18, "Specialized", 2441m },
                    { 19, "Cervelo", 1306m },
                    { 20, "Specialized", 4584m },
                    { 21, "Bianchi", 663m },
                    { 22, "Trek", 2172m },
                    { 23, "Pinarello", 712m },
                    { 24, "Bianchi", 2856m },
                    { 25, "Trek", 1815m },
                    { 26, "Scott", 3329m },
                    { 27, "Scott", 1940m },
                    { 28, "Giant", 4621m },
                    { 29, "Trek", 3154m },
                    { 30, "Cannondale", 4361m },
                    { 31, "Scott", 2832m },
                    { 32, "Cervelo", 1360m },
                    { 33, "Bianchi", 3795m },
                    { 34, "Scott", 4703m },
                    { 35, "Trek", 739m },
                    { 36, "Giant", 3272m },
                    { 37, "Cervelo", 3416m },
                    { 38, "Cannondale", 4057m },
                    { 39, "Trek", 1855m },
                    { 40, "Cervelo", 3267m },
                    { 41, "Giant", 4815m },
                    { 42, "Cervelo", 2182m },
                    { 43, "Specialized", 1880m },
                    { 44, "Pinarello", 3190m },
                    { 45, "Scott", 1832m },
                    { 46, "Trek", 4424m },
                    { 47, "Scott", 733m },
                    { 48, "Giant", 1574m },
                    { 49, "Trek", 1611m },
                    { 50, "Bianchi", 4371m }
                });

            migrationBuilder.InsertData(
                table: "shoppingBags",
                columns: new[] { "Id", "CustomerId", "Date" },
                values: new object[] { 1, 1, new DateTime(2023, 3, 22, 19, 10, 52, 145, DateTimeKind.Local).AddTicks(759) });

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBags_CustomerId",
                table: "shoppingBags",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingItems_ProductId",
                table: "shoppingItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingItems_ShoppingBagId",
                table: "shoppingItems",
                column: "ShoppingBagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shoppingItems");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "shoppingBags");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
