using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class DestinationFloor_BgColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "ToFriedlyName",
                table: "Move",
                newName: "ToFriendlyName");

            migrationBuilder.AddColumn<string>(
                name: "BackgroundColorcode",
                table: "DestinationFloor",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "BoxOwnerId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId",
                principalTable: "DestinationFloor",
                principalColumn: "DestinationFloorId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Move_MoveId",
                table: "Movingboxes",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes",
                column: "PackerId",
                principalTable: "Packers",
                principalColumn: "PackerId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.NoAction);
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

            migrationBuilder.DropColumn(
                name: "BackgroundColorcode",
                table: "DestinationFloor");

            migrationBuilder.RenameColumn(
                name: "ToFriendlyName",
                table: "Move",
                newName: "ToFriedlyName");

            migrationBuilder.AddForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "BoxOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId",
                principalTable: "DestinationFloor",
                principalColumn: "DestinationFloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Move_MoveId",
                table: "Movingboxes",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes",
                column: "PackerId",
                principalTable: "Packers",
                principalColumn: "PackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId");
        }
    }
}
