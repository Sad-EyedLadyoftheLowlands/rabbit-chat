using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class RoomJoinTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RabbitUserRoom");

            migrationBuilder.CreateTable(
                name: "UserRoom",
                columns: table => new
                {
                    RabbitUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoomId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoom", x => new { x.RoomId, x.RabbitUserId });
                    table.ForeignKey(
                        name: "FK_UserRoom_RabbitUsers_RabbitUserId",
                        column: x => x.RabbitUserId,
                        principalTable: "RabbitUsers",
                        principalColumn: "RabbitUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoom_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRoom_RabbitUserId",
                table: "UserRoom",
                column: "RabbitUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoom");

            migrationBuilder.CreateTable(
                name: "RabbitUserRoom",
                columns: table => new
                {
                    RoomsRoomId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersRabbitUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RabbitUserRoom", x => new { x.RoomsRoomId, x.UsersRabbitUserId });
                    table.ForeignKey(
                        name: "FK_RabbitUserRoom_RabbitUsers_UsersRabbitUserId",
                        column: x => x.UsersRabbitUserId,
                        principalTable: "RabbitUsers",
                        principalColumn: "RabbitUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RabbitUserRoom_Rooms_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RabbitUserRoom_UsersRabbitUserId",
                table: "RabbitUserRoom",
                column: "UsersRabbitUserId");
        }
    }
}
