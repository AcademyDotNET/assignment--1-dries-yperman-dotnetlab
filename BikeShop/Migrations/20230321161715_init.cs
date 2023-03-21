using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeShop.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(8,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "shoppingBags",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerId1 = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shoppingBags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shoppingBags_customers_CustomerId1",
                        column: x => x.CustomerId1,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shoppingItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ShoppingBagId = table.Column<long>(type: "bigint", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBags_CustomerId1",
                table: "shoppingBags",
                column: "CustomerId1");

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
