using Microsoft.EntityFrameworkCore.Migrations;

namespace Unlockd.Data.Migrations
{
    public partial class dsfsdafdsfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Testimonial");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Testimonial");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Testimonial",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Testimonial");

            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Testimonial",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Testimonial",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
