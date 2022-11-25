using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class addlistens : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Listens",
                table: "TheSong",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Listens",
                table: "TheSong");
        }
    }
}
