using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDelivery.Migrations
{
    public partial class NewPointBasket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Dishes",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_BasketId",
                table: "Dishes",
                column: "BasketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dishes_Baskets_BasketId",
                table: "Dishes",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dishes_Baskets_BasketId",
                table: "Dishes");

            migrationBuilder.DropIndex(
                name: "IX_Dishes_BasketId",
                table: "Dishes");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Dishes");
        }
    }
}
