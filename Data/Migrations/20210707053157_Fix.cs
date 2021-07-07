using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Fix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingCartItems_ShoppingCartItemId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingCartItemId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingCartItemId",
                table: "Products");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "ShoppingCartItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_Products_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ShoppingCartItemId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingCartItemId",
                table: "Products",
                column: "ShoppingCartItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingCartItems_ShoppingCartItemId",
                table: "Products",
                column: "ShoppingCartItemId",
                principalTable: "ShoppingCartItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
