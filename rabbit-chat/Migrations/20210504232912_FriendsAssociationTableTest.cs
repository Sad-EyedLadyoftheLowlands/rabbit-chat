using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class FriendsAssociationTableTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendsUserAssociations");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friendships");

            migrationBuilder.CreateTable(
                name: "FriendsUserAssociations",
                columns: table => new
                {
                    FriendsUserAssociationId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    SecondUserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsUserAssociations", x => x.FriendsUserAssociationId);
                    table.ForeignKey(
                        name: "FK_FriendsUserAssociations_RabbitUsers_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "RabbitUsers",
                        principalColumn: "RabbitUserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendsUserAssociations_RabbitUsers_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "RabbitUsers",
                        principalColumn: "RabbitUserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FriendsUserAssociations_FirstUserId",
                table: "FriendsUserAssociations",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsUserAssociations_SecondUserId",
                table: "FriendsUserAssociations",
                column: "SecondUserId");
        }
    }
}
