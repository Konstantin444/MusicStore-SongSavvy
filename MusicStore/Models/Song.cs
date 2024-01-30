using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Models
{
    public class Song
    {
        public Song()
        {
            Albums = new HashSet<AlbumSong>();
        }

        [Key]
        public int SongID { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The title can't be longer than 200 characters.")]
        [Display(Name = "Song Title")]
        public string SongTitle { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The genre can't be longer than 50 characters.")]
        public string Genre { get; set; }

        [Required]
        [Range(1900, 2024, ErrorMessage = "The release year must be between 1900 and 2024.")]
        [Display(Name = "Release Year")]
        public int ReleaseYear { get; set; }

        [ForeignKey("Artist")]
        public int ArtistID { get; set; }
        public virtual Artist? Artist { get; set; }

        public virtual ICollection<AlbumSong> Albums { get; set; }
    }
}
