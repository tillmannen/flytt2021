using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class addsrelationtomovefrompackerandboxowner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers");

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "Packers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "BoxOwners",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
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
                name: "FK_Packers_Move_MoveId",
                table: "Packers");

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "Packers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoveId",
                table: "BoxOwners",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers",
                column: "MoveId",
                principalTable: "Move",
                principalColumn: "MoveId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
