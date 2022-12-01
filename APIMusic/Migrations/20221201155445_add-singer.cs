using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class addsinger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Singer",
                table: "SongListeners",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Singer",
                table: "SongListeners");
        }
    }
}
