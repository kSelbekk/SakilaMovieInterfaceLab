using System;
using System.Collections.Generic;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.ViewModels
{
    public class MovieSelectedMovieViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ReleaseYear { get; set; }
        public byte LanguageId { get; set; }
        public byte? OriginalLanguageId { get; set; }
        public byte RentalDuration { get; set; }
        public decimal RentalRate { get; set; }
        public short? Length { get; set; }
        public decimal ReplacementCost { get; set; }
        public string Rating { get; set; }
        public string SpecialFeatures { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}