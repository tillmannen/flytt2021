using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class areaanddestinationFloorMoveId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationFloor_Move_MoveId",
                table: "DestinationFloor");

            migrationBuilder.AddColumn<int>(
                name: "FromArea",
                table: "Move",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "DestinationFloor",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationFloor_Move_MoveId",
                table: "DestinationFloor",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DestinationFloor_Move_MoveId",
                table: "DestinationFloor");

            migrationBuilder.DropColumn(
                name: "FromArea",
                table: "Move");

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "DestinationFloor",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_DestinationFloor_Move_MoveId",
                table: "DestinationFloor",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
