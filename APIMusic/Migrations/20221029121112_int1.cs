using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIMusic.Migrations
{
    public partial class int1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageCategory = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<int>(type: "int", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TheSong",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSong = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTheSongOfCategory = table.Column<int>(type: "int", nullable: true),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TheSong", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TheSong_Category_IdTheSongOfCategory",
                        column: x => x.IdTheSongOfCategory,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Listener",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdListenerOfUser = table.Column<int>(type: "int", nullable: true),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listener", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Listener_Users_IdListenerOfUser",
                        column: x => x.IdListenerOfUser,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expires = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Revoked = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedByIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReasonRevoked = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshToken_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAdvertisement = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImageAdvertisement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdAdvertisementOfTheSong = table.Column<int>(type: "int", nullable: false),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisement_TheSong_IdAdvertisementOfTheSong",
                        column: x => x.IdAdvertisementOfTheSong,
                        principalTable: "TheSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Singer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSinger = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TheSongId = table.Column<int>(type: "int", nullable: true),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Singer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Singer_TheSong_TheSongId",
                        column: x => x.TheSongId,
                        principalTable: "TheSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Listlike",
                columns: table => new
                {
                    IdTheSong = table.Column<int>(type: "int", nullable: false),
                    IdListener = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Listlike", x => new { x.IdListener, x.IdTheSong });
                    table.ForeignKey(
                        name: "FK_Listlike_Listener_IdListener",
                        column: x => x.IdListener,
                        principalTable: "Listener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Listlike_TheSong_IdTheSong",
                        column: x => x.IdTheSong,
                        principalTable: "TheSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePlaylist = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    ImagePlaylist = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdListenerOfPlaylist = table.Column<int>(type: "int", nullable: false),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_Listener_IdListenerOfPlaylist",
                        column: x => x.IdListenerOfPlaylist,
                        principalTable: "Listener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SongListeners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlSong = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdListenerOfSong = table.Column<int>(type: "int", nullable: false),
                    describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateUpdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongListeners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SongListeners_Listener_IdListenerOfSong",
                        column: x => x.IdListenerOfSong,
                        principalTable: "Listener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailSongSinger",
                columns: table => new
                {
                    IdTheSong = table.Column<int>(type: "int", nullable: false),
                    IdSinger = table.Column<int>(type: "int", nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailSongSinger", x => new { x.IdTheSong, x.IdSinger });
                    table.ForeignKey(
                        name: "FK_DetailSongSinger_Singer_IdSinger",
                        column: x => x.IdSinger,
                        principalTable: "Singer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailSongSinger_TheSong_IdTheSong",
                        column: x => x.IdTheSong,
                        principalTable: "TheSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FollowSingers",
                columns: table => new
                {
                    IdSinger = table.Column<int>(type: "int", nullable: false),
                    IdListener = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FollowSingers", x => new { x.IdSinger, x.IdListener });
                    table.ForeignKey(
                        name: "FK_FollowSingers_Listener_IdListener",
                        column: x => x.IdListener,
                        principalTable: "Listener",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FollowSingers_Singer_IdSinger",
                        column: x => x.IdSinger,
                        principalTable: "Singer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailPlaylistSong",
                columns: table => new
                {
                    IdPlaylist = table.Column<int>(type: "int", nullable: false),
                    IdTheSong = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Describe = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailPlaylistSong", x => new { x.IdPlaylist, x.IdTheSong });
                    table.ForeignKey(
                        name: "FK_DetailPlaylistSong_Playlist_IdPlaylist",
                        column: x => x.IdPlaylist,
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailPlaylistSong_TheSong_IdTheSong",
                        column: x => x.IdTheSong,
                        principalTable: "TheSong",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_IdAdvertisementOfTheSong",
                table: "Advertisement",
                column: "IdAdvertisementOfTheSong",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DetailPlaylistSong_IdTheSong",
                table: "DetailPlaylistSong",
                column: "IdTheSong");

            migrationBuilder.CreateIndex(
                name: "IX_DetailSongSinger_IdSinger",
                table: "DetailSongSinger",
                column: "IdSinger");

            migrationBuilder.CreateIndex(
                name: "IX_FollowSingers_IdListener",
                table: "FollowSingers",
                column: "IdListener");

            migrationBuilder.CreateIndex(
                name: "IX_Listener_IdListenerOfUser",
                table: "Listener",
                column: "IdListenerOfUser",
                unique: true,
                filter: "[IdListenerOfUser] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Listlike_IdTheSong",
                table: "Listlike",
                column: "IdTheSong");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_IdListenerOfPlaylist",
                table: "Playlist",
                column: "IdListenerOfPlaylist");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToken_UserId",
                table: "RefreshToken",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Singer_TheSongId",
                table: "Singer",
                column: "TheSongId");

            migrationBuilder.CreateIndex(
                name: "IX_SongListeners_IdListenerOfSong",
                table: "SongListeners",
                column: "IdListenerOfSong");

            migrationBuilder.CreateIndex(
                name: "IX_TheSong_IdTheSongOfCategory",
                table: "TheSong",
                column: "IdTheSongOfCategory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "DetailPlaylistSong");

            migrationBuilder.DropTable(
                name: "DetailSongSinger");

            migrationBuilder.DropTable(
                name: "FollowSingers");

            migrationBuilder.DropTable(
                name: "Listlike");

            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DropTable(
                name: "SongListeners");

            migrationBuilder.DropTable(
                name: "Playlist");

            migrationBuilder.DropTable(
                name: "Singer");

            migrationBuilder.DropTable(
                name: "Listener");

            migrationBuilder.DropTable(
                name: "TheSong");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
