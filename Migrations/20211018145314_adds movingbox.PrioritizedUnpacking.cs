using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class addsmovingboxPrioritizedUnpacking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PrioritizedUnpacking",
                table: "Movingboxes",
                type: "bit",
                nullable: false,
                defaultValue: false,
                defaultValueSql: "0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrioritizedUnpacking",
                table: "Movingboxes");
        }
    }
}
