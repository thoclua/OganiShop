using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OganiShopMVC.Migrations
{
    public partial class UpdateDBn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "ShopingCartItems");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Oders");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ShopingCartItems",
                newName: "Productid");

            migrationBuilder.RenameIndex(
                name: "IX_ShopingCartItems_ProductId",
                table: "ShopingCartItems",
                newName: "IX_ShopingCartItems_Productid");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShopingCartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "code",
                table: "Oders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userName",
                table: "Oders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCartItems_Products_Productid",
                table: "ShopingCartItems",
                column: "Productid",
                principalTable: "Products",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCartItems_Products_Productid",
                table: "ShopingCartItems");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShopingCartItems");

            migrationBuilder.DropColumn(
                name: "code",
                table: "Oders");

            migrationBuilder.DropColumn(
                name: "userName",
                table: "Oders");

            migrationBuilder.RenameColumn(
                name: "Productid",
                table: "ShopingCartItems",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShopingCartItems_Productid",
                table: "ShopingCartItems",
                newName: "IX_ShopingCartItems_ProductId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "ShopingCartItems",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "userid",
                table: "Oders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "id");
        }
    }
}
