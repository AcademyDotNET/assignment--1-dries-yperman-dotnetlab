using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BikeShop.Data.Migrations.BikeShop
{
    /// <inheritdoc />
    public partial class ShopInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingBags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingBags_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ShoppingBagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingItems_ShoppingBags_ShoppingBagId",
                        column: x => x.ShoppingBagId,
                        principalTable: "ShoppingBags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "FirstName", "Name" },
                values: new object[] { 1, "Dries", "Yperman" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Trek", 100m },
                    { 2, "Specialized", 200m },
                    { 3, "Giant", 300m },
                    { 4, "Cannondale", 400m },
                    { 5, "Scott", 500m },
                    { 6, "Bianchi", 600m },
                    { 7, "Cervelo", 700m },
                    { 8, "Pinarello", 800m },
                    { 9, "Trek", 900m },
                    { 10, "Specialized", 1000m },
                    { 11, "Giant", 1100m },
                    { 12, "Cannondale", 1200m },
                    { 13, "Scott", 1300m },
                    { 14, "Bianchi", 1400m },
                    { 15, "Cervelo", 1500m },
                    { 16, "Pinarello", 1600m },
                    { 17, "Trek", 1700m },
                    { 18, "Specialized", 1800m },
                    { 19, "Giant", 1900m },
                    { 20, "Cannondale", 2000m },
                    { 21, "Scott", 2100m },
                    { 22, "Bianchi", 2200m },
                    { 23, "Cervelo", 2300m },
                    { 24, "Pinarello", 2400m },
                    { 25, "Trek", 2500m },
                    { 26, "Specialized", 2600m },
                    { 27, "Giant", 2700m },
                    { 28, "Cannondale", 2800m },
                    { 29, "Scott", 2900m },
                    { 30, "Bianchi", 3000m },
                    { 31, "Cervelo", 3100m },
                    { 32, "Pinarello", 3200m },
                    { 33, "Trek", 3300m },
                    { 34, "Specialized", 3400m },
                    { 35, "Giant", 3500m },
                    { 36, "Cannondale", 3600m },
                    { 37, "Scott", 3700m },
                    { 38, "Bianchi", 3800m },
                    { 39, "Cervelo", 3900m },
                    { 40, "Pinarello", 4000m },
                    { 41, "Trek", 4100m },
                    { 42, "Specialized", 4200m },
                    { 43, "Giant", 4300m },
                    { 44, "Cannondale", 4400m },
                    { 45, "Scott", 4500m },
                    { 46, "Bianchi", 4600m },
                    { 47, "Cervelo", 4700m },
                    { 48, "Pinarello", 4800m },
                    { 49, "Trek", 4900m }
                });

            migrationBuilder.InsertData(
                table: "ShoppingBags",
                columns: new[] { "Id", "CustomerId", "Date" },
                values: new object[] { 1, 1, new DateTime(2023, 3, 28, 16, 9, 32, 660, DateTimeKind.Local).AddTicks(7982) });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingBags_CustomerId",
                table: "ShoppingBags",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ProductId",
                table: "ShoppingItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ShoppingBagId",
                table: "ShoppingItems",
                column: "ShoppingBagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingBags");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
