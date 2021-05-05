using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class FriendsAssociationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FriendsUserAssociations");

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
    }
}
