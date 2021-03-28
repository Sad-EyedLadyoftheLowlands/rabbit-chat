using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class AddedUnitRoomToBed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActUnitId",
                table: "ActBeds",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActBeds_ActUnitId",
                table: "ActBeds",
                column: "ActUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActBeds_ActUnits_ActUnitId",
                table: "ActBeds",
                column: "ActUnitId",
                principalTable: "ActUnits",
                principalColumn: "ActUnitId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActBeds_ActUnits_ActUnitId",
                table: "ActBeds");

            migrationBuilder.DropIndex(
                name: "IX_ActBeds_ActUnitId",
                table: "ActBeds");

            migrationBuilder.DropColumn(
                name: "ActUnitId",
                table: "ActBeds");
        }
    }
}
