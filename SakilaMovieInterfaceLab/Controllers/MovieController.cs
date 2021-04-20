﻿using System;
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
        public IActionResult Index(string q, string sortField, string sortOrder, string pageSize, int page = 1)
        {
            var query = _movieRepository.GetAllMovies().Where(film => q == null || film.Title.Contains(q.ToUpper()));
            var totalRowCount = query.Count();
            var size = 15;

            if (string.IsNullOrEmpty(sortField))
            {
                sortField = SortOptions.Title.ToString();
            }
            if (string.IsNullOrEmpty(sortOrder))
            {
                sortOrder = "asc";
            }
            if (!string.IsNullOrEmpty(pageSize))
            {
                size = int.Parse(pageSize);
            }

            if (sortField == SortOptions.Title.ToString())
            {
                query = sortOrder == "asc" ? query.OrderBy(t => t.Title) : query.OrderByDescending(t => t.Title);
            }
            if (sortField == SortOptions.ReleaseYear.ToString())
            {
                query = sortOrder == "asc" ? query.OrderBy(t => t.ReleaseYear) : query.OrderByDescending(t => t.ReleaseYear);
            }
            if (sortField == SortOptions.RentalRate.ToString())
            {
                query = sortOrder == "asc" ? query.OrderBy(t => t.RentalRate) : query.OrderByDescending(t => t.RentalRate);
            }

            var pageCount = (double)totalRowCount / size;
            var howManyToSKip = (page - 1) * size;
            query = query.Skip(howManyToSKip).Take(size);

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
                PageSize = size
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

        public IActionResult EditMovie(int id)
        {
            var viewModel = new EditMovieViewModel();

            var dbFilm = _movieRepository.GetSelectedMovie(id);

            viewModel.FilmId = dbFilm.FilmId;
            viewModel.Title = dbFilm.Title;
            viewModel.Lenght = dbFilm.Length;
            viewModel.Rating = dbFilm.Rating;
            viewModel.ReleaseYear = dbFilm.ReleaseYear;

            return View(viewModel);
        }
    }

    public enum SortOptions
    {
        Title,
        ReleaseYear,
        RentalRate
    }
}