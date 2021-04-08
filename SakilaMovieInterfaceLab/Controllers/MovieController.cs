using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SakilaMovieInterfaceLab.Data;
using SakilaMovieInterfaceLab.Services;
using SakilaMovieInterfaceLab.ViewModels;

namespace SakilaMovieInterfaceLab.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // GET
        public IActionResult Index()
        {
            var viewModel = new MovieIndexViewModel
            {
                Films = _movieRepository.GetAllMovies().Select(dbFilms => new MovieIndexViewModel.FilmViewModel
                {
                    Id = dbFilms.FilmId,
                    Title = dbFilms.Title,
                    ReleaseYear = dbFilms.ReleaseYear
                }).ToList()
            };

            return View(viewModel);
        }

        public IActionResult _SelectedMovie(int id)
        {
            var film = _movieRepository.GetSelectedMovie(id);

            var viewModel = new MovieSelectedMovieViewModel
            {
                Id = film.FilmId,
                Title = film.Title,
                ReleaseYear = film.ReleaseYear,
                Description = film.Description,
                Length = film.Length,
                LanguageId = film.LanguageId,
                LastUpdate = film.LastUpdate,
                Rating = film.Rating,
                RentalDuration = film.RentalDuration,
                RentalRate = film.RentalRate,
                ReplacementCost = film.ReplacementCost,
                OriginalLanguageId = film.OriginalLanguageId,
                SpecialFeatures = film.SpecialFeatures
            };

            return View(viewModel);
        }
    }
}