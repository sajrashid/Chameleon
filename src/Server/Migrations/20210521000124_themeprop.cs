using Microsoft.EntityFrameworkCore.Migrations;

namespace Chameleon.Server.Migrations
{
    public partial class themeprop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "AppUser",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Theme",
                table: "AppUser");
        }
    }
}
