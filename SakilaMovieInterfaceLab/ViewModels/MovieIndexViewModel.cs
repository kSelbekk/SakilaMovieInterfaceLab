using System.Collections.Generic;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<FilmViewModel> Films { get; set; } = new List<FilmViewModel>();
        public string q { get; set; }
        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public string OpositeSortOrder { get; set; }

        public class FilmViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
            public decimal RentalRate { get; set; }
        }
    }
}