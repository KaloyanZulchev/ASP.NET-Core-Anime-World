using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeWorld.Data.Migrations
{
    public partial class AddViewstColumInAnimeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Views",
                table: "Animes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Views",
                table: "Animes");
        }
    }
}
