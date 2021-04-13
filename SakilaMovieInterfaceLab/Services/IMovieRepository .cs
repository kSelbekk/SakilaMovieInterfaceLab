using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.Services
{
    public class CachedMovies : IMovieRepository
    {
        public static DateTime LastChecked;
        private readonly IMovieRepository _inner;
        private static Film _cachedFilm;

        public CachedMovies(IMovieRepository inner)
        {
            _inner = inner;
        }

        public IQueryable<Film> GetAllMovies()
        {
            return _inner.GetAllMovies();
        }

        public Film GetSelectedMovie(int id)
        {
            if (((DateTime.Now - LastChecked).TotalSeconds > 60) || _cachedFilm.FilmId.Equals(id))
            {
                LastChecked = DateTime.Now;

                _cachedFilm = _inner.GetSelectedMovie(id);
            }

            return _cachedFilm;
        }
    }

    public interface IMovieRepository
    {
        public IQueryable<Film> GetAllMovies();

        public Film GetSelectedMovie(int id);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly sakilaContext _sakilaContext;

        public MovieRepository(sakilaContext sakilaContext)
        {
            _sakilaContext = sakilaContext;
        }

        public IQueryable<Film> GetAllMovies()
        {
            return _sakilaContext.Films;
        }

        public Film GetSelectedMovie(int id)
        {
            return _sakilaContext.Films.FirstOrDefault(i => i.FilmId == id);
        }
    }
}