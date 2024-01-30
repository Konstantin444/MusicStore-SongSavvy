using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicStore.Models
{
    public class Artist
    {
        public Artist()
        {
            Songs = new HashSet<Song>();
        }

        [Key]
        public int ArtistID { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The name can't be longer than 100 characters.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "The name of the country can't be longer than 50 characters.")]
        public string Country { get; set; }

        [StringLength(500, ErrorMessage = "The biography can't be longer than 500 characters.")]
        public string Bio { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
