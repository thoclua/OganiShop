using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OganiShopMVC.Migrations
{
    public partial class updateDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ShopingCartItems_ProductId",
                table: "ShopingCartItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShopingCartItems_ProductId",
                table: "ShopingCartItems");
        }
    }
}
