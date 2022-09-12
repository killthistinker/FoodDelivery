using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodDelivery.Migrations
{
    public partial class Address : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "CustomerInfos",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "CustomerInfos",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "CustomerInfos");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "CustomerInfos");
        }
    }
}
