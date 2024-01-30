using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class AlbumSong
    {
        [Key]
        public int AlbumSongID { get; set; }

        [ForeignKey("Album")]
        public int AlbumID { get; set; }
        public virtual Album? Album { get; set; }

        [ForeignKey("Song")]
        public int SongID { get; set; }
        public virtual Song? Song { get; set; }
    }
}
