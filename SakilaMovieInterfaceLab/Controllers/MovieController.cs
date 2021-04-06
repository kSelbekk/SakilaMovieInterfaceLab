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
                    RelesYear = dbFilms.ReleaseYear
                }).ToList()
            };

            return View(viewModel);
        }
    }
}