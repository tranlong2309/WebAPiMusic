using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class int7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Singer_TheSong_TheSongId",
                table: "Singer");

            migrationBuilder.DropIndex(
                name: "IX_Singer_TheSongId",
                table: "Singer");

            migrationBuilder.DropColumn(
                name: "TheSongId",
                table: "Singer");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Listlike",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "Describe",
                table: "DetailSongSinger",
                newName: "describe");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "DetailSongSinger",
                newName: "DateUpdate");

            migrationBuilder.RenameColumn(
                name: "Describe",
                table: "DetailPlaylistSong",
                newName: "describe");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "DetailPlaylistSong",
                newName: "DateUpdate");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Listlike",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "describe",
                table: "Listlike",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DetailSongSinger",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "DetailPlaylistSong",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "Listlike");

            migrationBuilder.DropColumn(
                name: "describe",
                table: "Listlike");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DetailSongSinger");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DetailPlaylistSong");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "Listlike",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "describe",
                table: "DetailSongSinger",
                newName: "Describe");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "DetailSongSinger",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "describe",
                table: "DetailPlaylistSong",
                newName: "Describe");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "DetailPlaylistSong",
                newName: "CreateDate");

            migrationBuilder.AddColumn<int>(
                name: "TheSongId",
                table: "Singer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Singer_TheSongId",
                table: "Singer",
                column: "TheSongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Singer_TheSong_TheSongId",
                table: "Singer",
                column: "TheSongId",
                principalTable: "TheSong",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
