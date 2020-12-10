using Microsoft.EntityFrameworkCore.Migrations;

namespace GuessTheNumber.DAL.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GameOwnerName",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GameWinnerName",
                table: "Games",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Attempt",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GameOwnerName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "GameWinnerName",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Attempt");
        }
    }
}
