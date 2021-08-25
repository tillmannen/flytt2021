using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class packers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackedBy",
                table: "Movingboxes");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationFloor",
                table: "Movingboxes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Contents",
                table: "Movingboxes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackerId",
                table: "Movingboxes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Packers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_PackerId",
                table: "Movingboxes",
                column: "PackerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes",
                column: "PackerId",
                principalTable: "Packers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_Packers_PackerId",
                table: "Movingboxes");

            migrationBuilder.DropTable(
                name: "Packers");

            migrationBuilder.DropIndex(
                name: "IX_Movingboxes_PackerId",
                table: "Movingboxes");

            migrationBuilder.DropColumn(
                name: "PackerId",
                table: "Movingboxes");

            migrationBuilder.AlterColumn<int>(
                name: "DestinationFloor",
                table: "Movingboxes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Contents",
                table: "Movingboxes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "PackedBy",
                table: "Movingboxes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
