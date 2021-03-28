using Microsoft.EntityFrameworkCore.Migrations;

namespace rabbit_chat.Migrations
{
    public partial class ActiumTestingBetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActInfections",
                columns: table => new
                {
                    ActInfectionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActInfectionName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActInfections", x => x.ActInfectionId);
                });

            migrationBuilder.CreateTable(
                name: "ActUnits",
                columns: table => new
                {
                    ActUnitId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActUnits", x => x.ActUnitId);
                });

            migrationBuilder.CreateTable(
                name: "ActWorkflows",
                columns: table => new
                {
                    ActWorkflowId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActWorkflowText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActWorkflows", x => x.ActWorkflowId);
                });

            migrationBuilder.CreateTable(
                name: "ActRooms",
                columns: table => new
                {
                    ActRoomId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActRoomName = table.Column<string>(type: "TEXT", nullable: true),
                    ActUnitId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActRooms", x => x.ActRoomId);
                    table.ForeignKey(
                        name: "FK_ActRooms_ActUnits_ActUnitId",
                        column: x => x.ActUnitId,
                        principalTable: "ActUnits",
                        principalColumn: "ActUnitId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActBeds",
                columns: table => new
                {
                    ActBedId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ActBedName = table.Column<string>(type: "TEXT", nullable: true),
                    ActBedInfectionActInfectionId = table.Column<int>(type: "INTEGER", nullable: true),
                    ActBedWorkflowActWorkflowId = table.Column<int>(type: "INTEGER", nullable: true),
                    ActRoomId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActBeds", x => x.ActBedId);
                    table.ForeignKey(
                        name: "FK_ActBeds_ActInfections_ActBedInfectionActInfectionId",
                        column: x => x.ActBedInfectionActInfectionId,
                        principalTable: "ActInfections",
                        principalColumn: "ActInfectionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActBeds_ActRooms_ActRoomId",
                        column: x => x.ActRoomId,
                        principalTable: "ActRooms",
                        principalColumn: "ActRoomId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActBeds_ActWorkflows_ActBedWorkflowActWorkflowId",
                        column: x => x.ActBedWorkflowActWorkflowId,
                        principalTable: "ActWorkflows",
                        principalColumn: "ActWorkflowId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActBeds_ActBedInfectionActInfectionId",
                table: "ActBeds",
                column: "ActBedInfectionActInfectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ActBeds_ActBedWorkflowActWorkflowId",
                table: "ActBeds",
                column: "ActBedWorkflowActWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_ActBeds_ActRoomId",
                table: "ActBeds",
                column: "ActRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ActRooms_ActUnitId",
                table: "ActRooms",
                column: "ActUnitId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActBeds");

            migrationBuilder.DropTable(
                name: "ActInfections");

            migrationBuilder.DropTable(
                name: "ActRooms");

            migrationBuilder.DropTable(
                name: "ActWorkflows");

            migrationBuilder.DropTable(
                name: "ActUnits");
        }
    }
}
