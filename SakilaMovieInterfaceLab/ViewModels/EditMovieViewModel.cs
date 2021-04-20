using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SakilaMovieInterfaceLab.ViewModels
{
    public class EditMovieViewModel
    {
        [Key]
        public int FilmId { get; set; }

        [MaxLength(255)]
        public string Title { get; set; }

        [MaxLength(4)]
        public string ReleaseYear { get; set; }

        [Range(1, 1000)]
        public short? Lenght { get; set; }

        [MaxLength(10)]
        public string Rating { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }
    }
}