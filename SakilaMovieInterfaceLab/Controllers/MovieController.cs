using System;
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
        public IActionResult Index(string q, string sortField, string sortOrder, int pageSize = 15, int page = 1)
        {
            var query = _movieRepository.GetAllMovies().Where(film => q == null || film.Title.Contains(q.ToUpper()));
            var totalRowCount = query.Count();

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = "Title";
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "asc";
            }

            if (sortField == "Title")
            {
                query = sortOrder == "asc" ? query.OrderBy(t => t.Title) : query.OrderByDescending(t => t.Title);
            }
            if (sortField == "Release Year")
            {
                query = sortOrder == "asc" ? query.OrderBy(t => t.ReleaseYear) : query.OrderByDescending(t => t.ReleaseYear);
            }
            if (sortField == "Rental Rate")
            {
                query = sortOrder == "asc" ? query.OrderBy(t => t.RentalRate) : query.OrderByDescending(t => t.RentalRate);
            }

            var pageCount = (double)totalRowCount / pageSize;
            var howManyToSKip = (page - 1) * pageSize;
            query = query.Skip(howManyToSKip).Take(pageSize);

            var viewModel = new MovieIndexViewModel
            {
                Films = query
                    .Select(dbFilms => new MovieIndexViewModel.FilmViewModel
                    {
                        Id = dbFilms.FilmId,
                        Title = dbFilms.Title,
                        ReleaseYear = dbFilms.ReleaseYear,
                        RentalRate = dbFilms.RentalRate
                    }).ToList(),
                q = q,
                SortOrder = sortOrder,
                SortField = sortField,
                OpositeSortOrder = sortOrder == "asc" ? "desc" : "asc",
                Page = page,
                TotalPages = (int)Math.Ceiling(pageCount),
                PageSize = pageSize
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