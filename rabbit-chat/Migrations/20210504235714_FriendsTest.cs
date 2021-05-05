using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class FriendsTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.AddColumn<int>(
                name: "RabbitUserId1",
                table: "RabbitUsers",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RabbitUsers_RabbitUserId1",
                table: "RabbitUsers",
                column: "RabbitUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RabbitUsers_RabbitUsers_RabbitUserId1",
                table: "RabbitUsers",
                column: "RabbitUserId1",
                principalTable: "RabbitUsers",
                principalColumn: "RabbitUserId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RabbitUsers_RabbitUsers_RabbitUserId1",
                table: "RabbitUsers");

            migrationBuilder.DropIndex(
                name: "IX_RabbitUsers_RabbitUserId1",
                table: "RabbitUsers");

            migrationBuilder.DropColumn(
                name: "RabbitUserId1",
                table: "RabbitUsers");

            migrationBuilder.CreateTable(
                name: "Friendships",
                columns: table => new
                {
                    FirstUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friendships", x => new { x.FirstUserId, x.SecondUserId });
                    table.ForeignKey(
                        name: "FK_Friendships_RabbitUsers_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "RabbitUsers",
                        principalColumn: "RabbitUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friendships_RabbitUsers_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "RabbitUsers",
                        principalColumn: "RabbitUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_SecondUserId",
                table: "Friendships",
                column: "SecondUserId");
        }
    }
}
