using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class RoomRelationshipWithUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RabbitUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RabbitUsers_RoomId",
                table: "RabbitUsers",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_RabbitUsers_Rooms_RoomId",
                table: "RabbitUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RabbitUsers_Rooms_RoomId",
                table: "RabbitUsers");

            migrationBuilder.DropIndex(
                name: "IX_RabbitUsers_RoomId",
                table: "RabbitUsers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RabbitUsers");
        }
    }
}
