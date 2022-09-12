using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace FoodDelivery.Migrations
{
    public partial class CustomerInfos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DishId = table.Column<int>(type: "integer", nullable: false),
                    DishCount = table.Column<int>(type: "integer", nullable: false),
                    CustomerInfoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderInfos_CustomerInfos_CustomerInfoId",
                        column: x => x.CustomerInfoId,
                        principalTable: "CustomerInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderInfos_Dishes_DishId",
                        column: x => x.DishId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_CustomerInfoId",
                table: "OrderInfos",
                column: "CustomerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderInfos_DishId",
                table: "OrderInfos",
                column: "DishId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderInfos");

            migrationBuilder.DropTable(
                name: "CustomerInfos");
        }
    }
}
