using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodManager.Persistence.Migrations
{
    public partial class UpdateOrderItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Menus_OrderItems_OrderItemId",
                table: "Menus");

            migrationBuilder.DropIndex(
                name: "IX_Menus_OrderItemId",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "OrderItemId",
                table: "Menus");

            migrationBuilder.AddColumn<Guid>(
                name: "MenuId",
                table: "OrderItems",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_MenuId",
                table: "OrderItems",
                column: "MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Menus_MenuId",
                table: "OrderItems",
                column: "MenuId",
                principalTable: "Menus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Menus_MenuId",
                table: "OrderItems");

            migrationBuilder.DropIndex(
                name: "IX_OrderItems_MenuId",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "MenuId",
                table: "OrderItems");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderItemId",
                table: "Menus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Menus_OrderItemId",
                table: "Menus",
                column: "OrderItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Menus_OrderItems_OrderItemId",
                table: "Menus",
                column: "OrderItemId",
                principalTable: "OrderItems",
                principalColumn: "Id");
        }
    }
}
