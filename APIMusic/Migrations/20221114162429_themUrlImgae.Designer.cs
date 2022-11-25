﻿// <auto-generated />
using System;
using APIMusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APIMusic.Migrations
{
    [DbContext(typeof(MyDBContext))]
    [Migration("20221114162429_themUrlImgae")]
    partial class themUrlImgae
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APIMusic.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Advertisement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAdvertisementOfTheSong")
                        .HasColumnType("int");

                    b.Property<string>("ImageAdvertisement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAdvertisement")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdAdvertisementOfTheSong")
                        .IsUnique();

                    b.ToTable("Advertisement");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageAlbum")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NameAlbum")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageCategory")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("NameCategory")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("APIMusicEntities.Models.DetailPlaylistSong", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdPlaylist")
                        .HasColumnType("int");

                    b.Property<int>("IdTheSong")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "IdPlaylist", "IdTheSong");

                    b.HasIndex("IdPlaylist");

                    b.HasIndex("IdTheSong");

                    b.ToTable("DetailPlaylistSong");
                });

            modelBuilder.Entity("APIMusicEntities.Models.DetailSongSinger", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdTheSong")
                        .HasColumnType("int");

                    b.Property<int>("IdSinger")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "IdTheSong", "IdSinger");

                    b.HasIndex("IdSinger");

                    b.HasIndex("IdTheSong");

                    b.ToTable("DetailSongSinger");
                });

            modelBuilder.Entity("APIMusicEntities.Models.FollowSingers", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdSinger")
                        .HasColumnType("int");

                    b.Property<int>("IdListener")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "IdSinger", "IdListener");

                    b.HasIndex("IdListener");

                    b.HasIndex("IdSinger");

                    b.ToTable("FollowSingers");
                });

            modelBuilder.Entity("APIMusicEntities.Models.ListLike", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("IdListener")
                        .HasColumnType("int");

                    b.Property<int>("IdTheSong")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "IdListener", "IdTheSong");

                    b.HasIndex("IdListener");

                    b.HasIndex("IdTheSong");

                    b.ToTable("Listlike");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Listener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("IdListenerOfUser")
                        .HasColumnType("int");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdListenerOfUser")
                        .IsUnique()
                        .HasFilter("[IdListenerOfUser] IS NOT NULL");

                    b.ToTable("Listener");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Playlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdListenerOfPlaylist")
                        .HasColumnType("int");

                    b.Property<string>("ImagePlaylist")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NamePlaylist")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdListenerOfPlaylist");

                    b.ToTable("Playlist");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Singer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameSinger")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Singer");
                });

            modelBuilder.Entity("APIMusicEntities.Models.SongListener", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdListenerOfSong")
                        .HasColumnType("int");

                    b.Property<string>("IdUrlSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdListenerOfSong");

                    b.ToTable("SongListeners");
                });

            modelBuilder.Entity("APIMusicEntities.Models.TheSong", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateUpdate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdTheSongOfAlbum")
                        .HasColumnType("int");

                    b.Property<int?>("IdTheSongOfCategory")
                        .HasColumnType("int");

                    b.Property<string>("IdUrlSong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSong")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("describe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdTheSongOfAlbum");

                    b.HasIndex("IdTheSongOfCategory");

                    b.ToTable("TheSong");
                });

            modelBuilder.Entity("APIMusic.Entities.User", b =>
                {
                    b.OwnsMany("APIMusic.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<int>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<DateTime>("Created")
                                .HasColumnType("datetime2");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime>("Expires")
                                .HasColumnType("datetime2");

                            b1.Property<string>("ReasonRevoked")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("ReplacedByToken")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<DateTime?>("Revoked")
                                .HasColumnType("datetime2");

                            b1.Property<string>("RevokedByIp")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Token")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("UserId")
                                .HasColumnType("int");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("RefreshToken");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Advertisement", b =>
                {
                    b.HasOne("APIMusicEntities.Models.TheSong", "TheSong")
                        .WithOne("Advertisement")
                        .HasForeignKey("APIMusicEntities.Models.Advertisement", "IdAdvertisementOfTheSong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheSong");
                });

            modelBuilder.Entity("APIMusicEntities.Models.DetailPlaylistSong", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Playlist", "Playlist")
                        .WithMany("DetailPlaylistSongs")
                        .HasForeignKey("IdPlaylist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMusicEntities.Models.TheSong", "TheSong")
                        .WithMany("DetailPlaylistSongs")
                        .HasForeignKey("IdTheSong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Playlist");

                    b.Navigation("TheSong");
                });

            modelBuilder.Entity("APIMusicEntities.Models.DetailSongSinger", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Singer", "Singer")
                        .WithMany("DetailSongSingers")
                        .HasForeignKey("IdSinger")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMusicEntities.Models.TheSong", "TheSong")
                        .WithMany("DetailSongSingers")
                        .HasForeignKey("IdTheSong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Singer");

                    b.Navigation("TheSong");
                });

            modelBuilder.Entity("APIMusicEntities.Models.FollowSingers", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Listener", "Listener")
                        .WithMany("FollowSingers")
                        .HasForeignKey("IdListener")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMusicEntities.Models.Singer", "Singer")
                        .WithMany("FollowSingers")
                        .HasForeignKey("IdSinger")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listener");

                    b.Navigation("Singer");
                });

            modelBuilder.Entity("APIMusicEntities.Models.ListLike", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Listener", "Listener")
                        .WithMany("ListLikes")
                        .HasForeignKey("IdListener")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APIMusicEntities.Models.TheSong", "TheSong")
                        .WithMany("ListLikes")
                        .HasForeignKey("IdTheSong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listener");

                    b.Navigation("TheSong");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Listener", b =>
                {
                    b.HasOne("APIMusic.Entities.User", "User")
                        .WithOne("Listener")
                        .HasForeignKey("APIMusicEntities.Models.Listener", "IdListenerOfUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Playlist", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Listener", "Listener")
                        .WithMany("Playlists")
                        .HasForeignKey("IdListenerOfPlaylist")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listener");
                });

            modelBuilder.Entity("APIMusicEntities.Models.SongListener", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Listener", "Listener")
                        .WithMany("SongListeners")
                        .HasForeignKey("IdListenerOfSong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Listener");
                });

            modelBuilder.Entity("APIMusicEntities.Models.TheSong", b =>
                {
                    b.HasOne("APIMusicEntities.Models.Album", "Album")
                        .WithMany("TheSongs")
                        .HasForeignKey("IdTheSongOfAlbum")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("APIMusicEntities.Models.Category", "Category")
                        .WithMany("TheSongs")
                        .HasForeignKey("IdTheSongOfCategory")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Album");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("APIMusic.Entities.User", b =>
                {
                    b.Navigation("Listener");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Album", b =>
                {
                    b.Navigation("TheSongs");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Category", b =>
                {
                    b.Navigation("TheSongs");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Listener", b =>
                {
                    b.Navigation("FollowSingers");

                    b.Navigation("ListLikes");

                    b.Navigation("Playlists");

                    b.Navigation("SongListeners");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Playlist", b =>
                {
                    b.Navigation("DetailPlaylistSongs");
                });

            modelBuilder.Entity("APIMusicEntities.Models.Singer", b =>
                {
                    b.Navigation("DetailSongSingers");

                    b.Navigation("FollowSingers");
                });

            modelBuilder.Entity("APIMusicEntities.Models.TheSong", b =>
                {
                    b.Navigation("Advertisement");

                    b.Navigation("DetailPlaylistSongs");

                    b.Navigation("DetailSongSingers");

                    b.Navigation("ListLikes");
                });
#pragma warning restore 612, 618
        }
    }
}
