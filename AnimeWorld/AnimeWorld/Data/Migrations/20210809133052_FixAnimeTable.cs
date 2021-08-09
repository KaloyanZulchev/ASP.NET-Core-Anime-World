using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimeWorld.Data.Migrations
{
    public partial class FixAnimeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextSesonId",
                table: "Animes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NextSesonId",
                table: "Animes",
                type: "int",
                nullable: true);
        }
    }
}
