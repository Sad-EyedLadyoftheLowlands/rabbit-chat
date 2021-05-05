using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class RestructuredRelationshipsUntested : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_RabbitUsers_Rooms_RoomId",
                table: "RabbitUsers");

            migrationBuilder.DropIndex(
                name: "IX_RabbitUsers_RoomId",
                table: "RabbitUsers");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "RabbitUsers");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Messages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "RabbitUserRoom");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "RabbitUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "Messages",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_RabbitUsers_RoomId",
                table: "RabbitUsers",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Rooms_RoomId",
                table: "Messages",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RabbitUsers_Rooms_RoomId",
                table: "RabbitUsers",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
