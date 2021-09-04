using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class somechange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers");

            migrationBuilder.RenameColumn(
                name: "PackerId",
                table: "Packers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BoxOwnerId",
                table: "BoxOwners",
                newName: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoxOwners_Move_MoveId",
                table: "BoxOwners");

            migrationBuilder.DropForeignKey(
                name: "FK_Packers_Move_MoveId",
                table: "Packers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Packers",
                newName: "PackerId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BoxOwners",
                newName: "BoxOwnerId");

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
