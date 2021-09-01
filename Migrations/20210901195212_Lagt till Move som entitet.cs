using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class LagttillMovesomentitet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packers",
                table: "Packers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movingboxes",
                table: "Movingboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoxOwners",
                table: "BoxOwners");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Packers",
                newName: "MoveId");

            migrationBuilder.RenameColumn(
                name: "DestinationFloor",
                table: "Movingboxes",
                newName: "MoveId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Movingboxes",
                newName: "DestinationFloorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BoxOwners",
                newName: "MoveId");

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "Packers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PackerId",
                table: "Packers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PackerId",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BoxOwnerId",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DestinationFloorId",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MovingboxId",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "DestinationFloorEnum",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "BoxOwners",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "BoxOwnerId",
                table: "BoxOwners",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packers",
                table: "Packers",
                column: "PackerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movingboxes",
                table: "Movingboxes",
                column: "MovingboxId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoxOwners",
                table: "BoxOwners",
                column: "BoxOwnerId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Packers_MoveId",
                table: "Packers",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_MoveId",
                table: "Movingboxes",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_BoxOwners_MoveId",
                table: "BoxOwners",
                column: "MoveId");

            migrationBuilder.CreateIndex(
                name: "IX_DestinationFloor_MoveId",
                table: "DestinationFloor",
                column: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "BoxOwnerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId",
                principalTable: "DestinationFloor",
                principalColumn: "DestinationFloorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Move_MoveId",
                table: "Movingboxes",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes",
                column: "PackerId",
                principalTable: "Packers",
                principalColumn: "PackerId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_Move_MoveId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers");

            migrationBuilder.DropTable(
                name: "DestinationFloor");

            migrationBuilder.DropTable(
                name: "Move");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Packers",
                table: "Packers");

            migrationBuilder.DropIndex(
                name: "IX_Packers_MoveId",
                table: "Packers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movingboxes",
                table: "Movingboxes");

            migrationBuilder.DropIndex(
                name: "IX_Movingboxes_DestinationFloorId",
                table: "Movingboxes");

            migrationBuilder.DropIndex(
                name: "IX_Movingboxes_MoveId",
                table: "Movingboxes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BoxOwners",
                table: "BoxOwners");

            migrationBuilder.DropIndex(
                name: "IX_BoxOwners_MoveId",
                table: "BoxOwners");

            migrationBuilder.DropColumn(
                name: "PackerId",
                table: "Packers");

            migrationBuilder.DropColumn(
                name: "MovingboxId",
                table: "Movingboxes");

            migrationBuilder.DropColumn(
                name: "DestinationFloorEnum",
                table: "Movingboxes");

            migrationBuilder.DropColumn(
                name: "BoxOwnerId",
                table: "BoxOwners");

            migrationBuilder.RenameColumn(
                name: "MoveId",
                table: "Packers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MoveId",
                table: "Movingboxes",
                newName: "DestinationFloor");

            migrationBuilder.RenameColumn(
                name: "DestinationFloorId",
                table: "Movingboxes",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MoveId",
                table: "BoxOwners",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Packers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PackerId",
                table: "Movingboxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BoxOwnerId",
                table: "Movingboxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "BoxOwners",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Packers",
                table: "Packers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movingboxes",
                table: "Movingboxes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BoxOwners",
                table: "BoxOwners",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes",
                column: "PackerId",
                principalTable: "Packers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
