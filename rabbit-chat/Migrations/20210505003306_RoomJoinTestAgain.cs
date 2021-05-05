using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class RoomJoinTestAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_RabbitUsers_RabbitUserId",
                table: "UserRoom");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoom_Rooms_RoomId",
                table: "UserRoom");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom");

            migrationBuilder.RenameTable(
                name: "UserRoom",
                newName: "UserRooms");

            migrationBuilder.RenameIndex(
                name: "IX_UserRoom_RabbitUserId",
                table: "UserRooms",
                newName: "IX_UserRooms_RabbitUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms",
                columns: new[] { "RoomId", "RabbitUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_RabbitUsers_RabbitUserId",
                table: "UserRooms",
                column: "RabbitUserId",
                principalTable: "RabbitUsers",
                principalColumn: "RabbitUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_RabbitUsers_RabbitUserId",
                table: "UserRooms");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRooms_Rooms_RoomId",
                table: "UserRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRooms",
                table: "UserRooms");

            migrationBuilder.RenameTable(
                name: "UserRooms",
                newName: "UserRoom");

            migrationBuilder.RenameIndex(
                name: "IX_UserRooms_RabbitUserId",
                table: "UserRoom",
                newName: "IX_UserRoom_RabbitUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRoom",
                table: "UserRoom",
                columns: new[] { "RoomId", "RabbitUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_RabbitUsers_RabbitUserId",
                table: "UserRoom",
                column: "RabbitUserId",
                principalTable: "RabbitUsers",
                principalColumn: "RabbitUserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRoom_Rooms_RoomId",
                table: "UserRoom",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
