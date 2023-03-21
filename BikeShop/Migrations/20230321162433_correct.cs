using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeShop.Migrations
{
    /// <inheritdoc />
    public partial class correct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBags_customers_CustomerId1",
                table: "shoppingBags");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBags_CustomerId1",
                table: "shoppingBags");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "shoppingBags");

            migrationBuilder.AlterColumn<long>(
                name: "CustomerId",
                table: "shoppingBags",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBags_CustomerId",
                table: "shoppingBags",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBags_customers_CustomerId",
                table: "shoppingBags",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingBags_customers_CustomerId",
                table: "shoppingBags");

            migrationBuilder.DropIndex(
                name: "IX_shoppingBags_CustomerId",
                table: "shoppingBags");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "shoppingBags",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "CustomerId1",
                table: "shoppingBags",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_shoppingBags_CustomerId1",
                table: "shoppingBags",
                column: "CustomerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingBags_customers_CustomerId1",
                table: "shoppingBags",
                column: "CustomerId1",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
