using System.Collections.Generic;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<FilmViewModel> Films { get; set; } = new List<FilmViewModel>();

        public class FilmViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string RelesYear { get; set; }
        }
    }
}