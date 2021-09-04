using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Move",
                columns: table => new
                {
                    MoveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromFriendlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToFriedlyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoveDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByUserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Move", x => x.MoveId);
                });

            migrationBuilder.CreateTable(
                name: "BoxOwners",
                columns: table => new
                {
                    BoxOwnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxOwners", x => x.BoxOwnerId);
                    table.ForeignKey(
                        name: "FK_BoxOwners_Move_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Move",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "DestinationFloor",
                columns: table => new
                {
                    DestinationFloorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colorcode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DestinationFloor", x => x.DestinationFloorId);
                    table.ForeignKey(
                        name: "FK_DestinationFloor_Move_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Move",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Packers",
                columns: table => new
                {
                    PackerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packers", x => x.PackerId);
                    table.ForeignKey(
                        name: "FK_Packers_Move_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Move",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Movingboxes",
                columns: table => new
                {
                    MovingboxId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marking = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinationFloorEnum = table.Column<int>(type: "int", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUnpacked = table.Column<bool>(type: "bit", nullable: false),
                    DestinationFloorId = table.Column<int>(type: "int", nullable: false),
                    PackerId = table.Column<int>(type: "int", nullable: false),
                    BoxOwnerId = table.Column<int>(type: "int", nullable: false),
                    MoveId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movingboxes", x => x.MovingboxId);
                    table.ForeignKey(
                        name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                        column: x => x.BoxOwnerId,
                        principalTable: "BoxOwners",
                        principalColumn: "BoxOwnerId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                        column: x => x.DestinationFloorId,
                        principalTable: "DestinationFloor",
                        principalColumn: "DestinationFloorId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movingboxes_Move_MoveId",
                        column: x => x.MoveId,
                        principalTable: "Move",
                        principalColumn: "MoveId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Movingboxes_Packers_PackerId",
                        column: x => x.PackerId,
                        principalTable: "Packers",
                        principalColumn: "PackerId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoxOwners_MoveId",
                table: "BoxOwners",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationFloor_MoveId",
                table: "DestinationFloor",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_MoveId",
                table: "Movingboxes",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_PackerId",
                table: "Movingboxes",
                column: "PackerId");

            migrationBuilder.CreateIndex(
                name: "IX_Packers_MoveId",
                table: "Packers",
                column: "MoveId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movingboxes");

            migrationBuilder.DropTable(
                name: "BoxOwners");

            migrationBuilder.DropTable(
                name: "DestinationFloor");

            migrationBuilder.DropTable(
                name: "Packers");

            migrationBuilder.DropTable(
                name: "Move");
        }
    }
}
