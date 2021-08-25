using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class boxes_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoxOwnerId",
                table: "Movingboxes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsUnpacked",
                table: "Movingboxes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PackedBy",
                table: "Movingboxes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BoxOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoxOwners", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movingboxes_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes",
                column: "BoxOwnerId",
                principalTable: "BoxOwners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movingboxes_BoxOwners_BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropTable(
                name: "BoxOwners");

            migrationBuilder.DropIndex(
                name: "IX_Movingboxes_BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropColumn(
                name: "BoxOwnerId",
                table: "Movingboxes");

            migrationBuilder.DropColumn(
                name: "IsUnpacked",
                table: "Movingboxes");

            migrationBuilder.DropColumn(
                name: "PackedBy",
                table: "Movingboxes");
        }
    }
}
