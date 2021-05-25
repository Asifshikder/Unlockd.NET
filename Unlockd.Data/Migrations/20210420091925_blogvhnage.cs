using Microsoft.EntityFrameworkCore.Migrations;

namespace Unlockd.Data.Migrations
{
    public partial class blogvhnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ShortDesciption",
                table: "BlogPost",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShortDesciption",
                table: "BlogPost");
        }
    }
}
