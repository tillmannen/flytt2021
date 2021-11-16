using Microsoft.EntityFrameworkCore.Migrations;

namespace flytt2021.Migrations
{
    public partial class UserInvitesInvitedBy : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAnswered",
                table: "UserMoveInvites");

            migrationBuilder.AddColumn<string>(
                name: "InvitedByUserName",
                table: "UserMoveInvites",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvitedByUserName",
                table: "UserMoveInvites");

            migrationBuilder.AddColumn<bool>(
                name: "IsAnswered",
                table: "UserMoveInvites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
