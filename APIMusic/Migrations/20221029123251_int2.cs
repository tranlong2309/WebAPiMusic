using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class int2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdTheSongOfAlbum",
                table: "TheSong",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUrlSong",
                table: "TheSong",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdUrlSong",
                table: "SongListeners",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAlbum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageAlbum = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfCategory",
                table: "TheSong",
                column: "IdTheSongOfCategory",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TheSong_Album_IdTheSongOfCategory",
                table: "TheSong");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropColumn(
                name: "IdTheSongOfAlbum",
                table: "TheSong");

            migrationBuilder.DropColumn(
                name: "IdUrlSong",
                table: "TheSong");

            migrationBuilder.DropColumn(
                name: "IdUrlSong",
                table: "SongListeners");
        }
    }
}
