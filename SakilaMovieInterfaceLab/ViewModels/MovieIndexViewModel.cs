using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.ViewModels
{
    public class MovieIndexViewModel
    {
        public List<FilmViewModel> Films { get; set; } = new List<FilmViewModel>();

        [StringLength(25)]
        public string q { get; set; }

        public string SortOrder { get; set; }
        public string SortField { get; set; }
        public string OpositeSortOrder { get; set; }
        public int Page { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }

        public List<SelectListItem> PageSizing { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "15", Text = "15"},
            new SelectListItem {Value = "30", Text = "30"},
            new SelectListItem {Value = "50", Text = "50"}
        };

        public class FilmViewModel
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string ReleaseYear { get; set; }
            public decimal RentalRate { get; set; }
        }
    }
}