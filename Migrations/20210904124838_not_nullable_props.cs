using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class not_nullable_props : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes");

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
                name: "DestinationFloorId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId",
                principalTable: "DestinationFloor",
                principalColumn: "DestinationFloorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes",
                column: "PackerId",
                principalTable: "Packers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes");

            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes");

            migrationBuilder.AlterColumn<int>(
                name: "PackerId",
                table: "Movingboxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationFloorId",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_DestinationFloor_DestinationFloorId",
                table: "Movingboxes",
                column: "DestinationFloorId",
                principalTable: "DestinationFloor",
                principalColumn: "DestinationFloorId",
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
