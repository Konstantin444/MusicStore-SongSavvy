using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Album
    {
        public Album()
        {
            Songs = new HashSet<AlbumSong>();
        }

        [Key]
        public int AlbumID { get; set; }

        [Required]
        [Url]
        [Display(Name = "Album Cover")]
        public string AlbumCoverURL { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "The title can't be longer than 200 characters.")]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public virtual ICollection<AlbumSong> Songs { get; set; }
    }
}
