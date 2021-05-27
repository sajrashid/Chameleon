using Microsoft.EntityFrameworkCore.Migrations;

namespace Chameleon.Server.Migrations
{
    public partial class removedPropsFromUser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AppUser");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "AppUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AppUser",
                type: "TEXT",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AppUser",
                type: "TEXT",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "AppUser",
                type: "TEXT",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }
    }
}
