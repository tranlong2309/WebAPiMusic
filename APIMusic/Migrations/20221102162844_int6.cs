using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class int6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfAlbum",
                table: "TheSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Album1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album1",
                table: "Album1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheSong_Album1_IdTheSongOfAlbum",
                table: "TheSong",
                column: "IdTheSongOfAlbum",
                principalTable: "Album1",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheSong_Album1_IdTheSongOfAlbum",
                table: "TheSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album1",
                table: "Album1");

            migrationBuilder.RenameTable(
                name: "Album1",
                newName: "Album");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfAlbum",
                table: "TheSong",
                column: "IdTheSongOfAlbum",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
