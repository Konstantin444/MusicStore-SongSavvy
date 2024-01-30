using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Data
{
    public class MusicStoreContext : DbContext
    {
        public MusicStoreContext(DbContextOptions<MusicStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<AlbumSong> AlbumSongs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AlbumSong>()
                .HasKey(als => als.AlbumSongID);

            modelBuilder.Entity<AlbumSong>()
                .HasOne(als => als.Album)
                .WithMany(a => a.Songs)
                .HasForeignKey(als => als.AlbumID);

            modelBuilder.Entity<AlbumSong>()
                .HasOne(als => als.Song)
                .WithMany(s => s.Albums)
                .HasForeignKey(als => als.SongID);
        }
    }
}
