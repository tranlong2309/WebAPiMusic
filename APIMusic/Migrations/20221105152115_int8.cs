using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class int8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheSong_Album1_IdTheSongOfAlbum",
                table: "TheSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listlike",
                table: "Listlike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowSingers",
                table: "FollowSingers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailSongSinger",
                table: "DetailSongSinger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailPlaylistSong",
                table: "DetailPlaylistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album1",
                table: "Album1");

            migrationBuilder.RenameTable(
                name: "Album1",
                newName: "Album");

            migrationBuilder.RenameColumn(
                name: "Describe",
                table: "FollowSingers",
                newName: "describe");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "FollowSingers",
                newName: "DateUpdate");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "FollowSingers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listlike",
                table: "Listlike",
                columns: new[] { "Id", "IdListener", "IdTheSong" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowSingers",
                table: "FollowSingers",
                columns: new[] { "Id", "IdSinger", "IdListener" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailSongSinger",
                table: "DetailSongSinger",
                columns: new[] { "Id", "IdTheSong", "IdSinger" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailPlaylistSong",
                table: "DetailPlaylistSong",
                columns: new[] { "Id", "IdPlaylist", "IdTheSong" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Album",
                table: "Album",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Listlike_IdListener",
                table: "Listlike",
                column: "IdListener");

            migrationBuilder.CreateIndex(
                name: "IX_FollowSingers_IdSinger",
                table: "FollowSingers",
                column: "IdSinger");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSongSinger_IdTheSong",
                table: "DetailSongSinger",
                column: "IdTheSong");

            migrationBuilder.CreateIndex(
                name: "IX_DetailPlaylistSong_IdPlaylist",
                table: "DetailPlaylistSong",
                column: "IdPlaylist");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Listlike",
                table: "Listlike");

            migrationBuilder.DropIndex(
                name: "IX_Listlike_IdListener",
                table: "Listlike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FollowSingers",
                table: "FollowSingers");

            migrationBuilder.DropIndex(
                name: "IX_FollowSingers_IdSinger",
                table: "FollowSingers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailSongSinger",
                table: "DetailSongSinger");

            migrationBuilder.DropIndex(
                name: "IX_DetailSongSinger_IdTheSong",
                table: "DetailSongSinger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailPlaylistSong",
                table: "DetailPlaylistSong");

            migrationBuilder.DropIndex(
                name: "IX_DetailPlaylistSong_IdPlaylist",
                table: "DetailPlaylistSong");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Album",
                table: "Album");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FollowSingers");

            migrationBuilder.RenameTable(
                name: "Album",
                newName: "Album1");

            migrationBuilder.RenameColumn(
                name: "describe",
                table: "FollowSingers",
                newName: "Describe");

            migrationBuilder.RenameColumn(
                name: "DateUpdate",
                table: "FollowSingers",
                newName: "CreateDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Listlike",
                table: "Listlike",
                columns: new[] { "IdListener", "IdTheSong" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FollowSingers",
                table: "FollowSingers",
                columns: new[] { "IdSinger", "IdListener" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailSongSinger",
                table: "DetailSongSinger",
                columns: new[] { "IdTheSong", "IdSinger" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailPlaylistSong",
                table: "DetailPlaylistSong",
                columns: new[] { "IdPlaylist", "IdTheSong" });

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
    }
}
