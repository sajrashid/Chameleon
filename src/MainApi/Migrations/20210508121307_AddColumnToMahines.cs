using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneralApi.Migrations
{
    public partial class AddColumnToMahines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Default",
                table: "Machines",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Default",
                table: "Machines");
        }
    }
}
