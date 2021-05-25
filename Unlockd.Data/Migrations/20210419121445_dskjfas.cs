using Microsoft.EntityFrameworkCore.Migrations;

namespace Unlockd.Data.Migrations
{
    public partial class dskjfas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarrierImage",
                table: "NetworkCarrier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CovorPhoto",
                table: "NetworkCarrier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "NetworkCarrier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CovorPhoto",
                table: "Brand",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Brand",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarrierImage",
                table: "NetworkCarrier");

            migrationBuilder.DropColumn(
                name: "CovorPhoto",
                table: "NetworkCarrier");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "NetworkCarrier");

            migrationBuilder.DropColumn(
                name: "CovorPhoto",
                table: "Brand");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Brand");
        }
    }
}
