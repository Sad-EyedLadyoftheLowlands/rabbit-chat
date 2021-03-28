using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class ActiumTestingBetterer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActUnitName",
                table: "ActUnits",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActUnitName",
                table: "ActUnits");
        }
    }
}
