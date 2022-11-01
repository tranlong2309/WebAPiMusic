using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class int5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfCategory",
                table: "TheSong");

            migrationBuilder.CreateIndex(
                name: "IX_TheSong_IdTheSongOfAlbum",
                table: "TheSong",
                column: "IdTheSongOfAlbum");

            migrationBuilder.AddForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfAlbum",
                table: "TheSong",
                column: "IdTheSongOfAlbum",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfAlbum",
                table: "TheSong");

            migrationBuilder.DropIndex(
                name: "IX_TheSong_IdTheSongOfAlbum",
                table: "TheSong");

            migrationBuilder.AddForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfCategory",
                table: "TheSong",
                column: "IdTheSongOfCategory",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
