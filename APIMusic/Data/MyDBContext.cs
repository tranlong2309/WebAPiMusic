using APIMusic.Entities;
using APIMusicEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace APIMusic.Data
{
    public class MyDBContext : DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {
        }

        #region Dbset

        public DbSet<TheSong> TheSongs { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<DetailSongSinger> DetailSongSingers { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Listener> Listeners { get; set; }
        public DbSet<Playlist> Playlists     { get; set; }
        public DbSet<DetailPlaylistSong> DetailPlaylistSongs { get; set; }
        public DbSet<FollowSingers> FollowSingers { get; set; }
        public DbSet<SongListener> SongListeners { get; set; }
        public DbSet<User> Users { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TheSong>(entity =>
            {
                entity.ToTable("TheSong");
                entity.HasKey(k => k.Id);
                entity.Property(p => p.NameSong)
                .IsRequired(true)
                .HasMaxLength(250);
                entity.Property(p => p.Url)
                .IsRequired(true);
                entity.Property(p => p.Image)
               .IsRequired(true);
            });

            modelBuilder.Entity<Singer>(entity =>
            {
                entity.ToTable("Singer");
                entity.HasKey(k => k.Id);
                entity.Property(p => p.NameSinger)
                .IsRequired(true)
                .HasMaxLength(250);
            });

            modelBuilder.Entity<DetailSongSinger>(entity =>
            {
                entity.ToTable("DetailSongSinger");
                entity.HasKey(k => new { k.IdTheSong, k.IdSinger });

                entity.HasOne(e => e.TheSong)
                .WithMany(w => w.DetailSongSingers)
                .HasForeignKey(f => f.IdTheSong);

                  entity.HasOne(e => e.Singer)
                .WithMany(w => w.DetailSongSingers)
                .HasForeignKey(f => f.IdSinger);

            });

            modelBuilder.Entity<Advertisement>(entity =>
            {
                entity.ToTable("Advertisement");
                entity.Property(p => p.NameAdvertisement)
                .IsRequired(true)
                .HasMaxLength(250);
                entity.HasOne<TheSong>(e => e.TheSong)
                .WithOne(w => w.Advertisement)
                .HasForeignKey<Advertisement>(e => e.IdAdvertisementOfTheSong);
            });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.Property(e => e.NameCategory)
                .IsRequired(true)
                .HasMaxLength(250);
                entity.Property(e => e.ImageCategory)
                 .IsRequired(true)
                .HasMaxLength(250);
                entity.HasMany<TheSong>(t => t.TheSongs)
                .WithOne(e => e.Category)
                .HasForeignKey(e => e.IdTheSongOfCategory)
                .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Listener>(entity =>
            {
                entity.ToTable("Listener");
                entity.Property(p => p.FullName)
                .IsRequired(true)
                .HasMaxLength(250);
                entity.HasKey(e => e.Id);
                entity.HasOne<User>(e => e.User)
                .WithOne(e => e.Listener)
                .HasForeignKey<Listener>(e => e.IdListenerOfUser);
                entity.HasMany<SongListener>(t => t.SongListeners)
                .WithOne(e => e.Listener)
                .HasForeignKey(e => e.IdListenerOfSong)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ListLike>(entity =>
            {
                entity.ToTable("Listlike");
                entity.HasKey(k => new { k.IdListener, k.IdTheSong });

                entity.HasOne(e => e.TheSong)
                .WithMany(w => w.ListLikes)
                .HasForeignKey(f => f.IdTheSong);

                entity.HasOne(e => e.Listener)
              .WithMany(w => w.ListLikes)
              .HasForeignKey(f => f.IdListener);

            });

            modelBuilder.Entity<Playlist>(entity => 
            {
                entity.ToTable("Playlist");
                entity.HasKey(h => h.Id);
                entity.Property(e => e.NamePlaylist)
                .IsRequired(true)
                .HasMaxLength(250);
                entity.Property(e => e.ImagePlaylist)
                .IsRequired(true);
                entity.HasOne<Listener>(e => e.Listener)
                .WithMany(e => e.Playlists)
                .HasForeignKey(e => e.IdListenerOfPlaylist)
                .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<DetailPlaylistSong>(entity =>
            {
                entity.ToTable("DetailPlaylistSong");
                entity.HasKey(k => new { k.IdPlaylist, k.IdTheSong });

                entity.HasOne(e => e.TheSong)
                .WithMany(w => w.DetailPlaylistSongs)
                .HasForeignKey(f => f.IdTheSong);

                entity.HasOne(e => e.Playlist)
              .WithMany(w => w.DetailPlaylistSongs)
              .HasForeignKey(f => f.IdPlaylist);

            });
            modelBuilder.Entity<FollowSingers>(entity =>
            {
                entity.ToTable("FollowSingers");
                entity.HasKey(k => new { k.IdSinger, k.IdListener });

                entity.HasOne(e => e.Singer)
                .WithMany(w => w.FollowSingers)
                .HasForeignKey(f => f.IdSinger);

                entity.HasOne(e => e.Listener)
              .WithMany(w => w.FollowSingers)
              .HasForeignKey(f => f.IdListener);

            });
            modelBuilder.Entity<Album>(entity =>
            {
                entity.ToTable("Album");
                entity.Property(e => e.NameAlbum)
                .IsRequired(true)
                .HasMaxLength(250);
                entity.Property(e => e.ImageAlbum)
                 .IsRequired(true)
                .HasMaxLength(250);
                entity.HasMany<TheSong>(t => t.TheSongs)
                .WithOne(e => e.Album)
                .HasForeignKey(e => e.IdTheSongOfAlbum)
                .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
