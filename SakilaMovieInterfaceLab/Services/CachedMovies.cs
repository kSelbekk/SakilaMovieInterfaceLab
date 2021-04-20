using System;
using System.Linq;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.Services
{
    //public class CachedMovies : IMovieRepository
    //{
    //    public static DateTime LastChecked;
    //    private readonly IMovieRepository _inner;
    //    private static Film _cachedFilm;

    //    public CachedMovies(IMovieRepository inner)
    //    {
    //        _inner = inner;
    //    }

    //    public IQueryable<Film> GetAllMovies()
    //    {
    //        return _inner.GetAllMovies();
    //    }

    //    public Film GetSelectedMovie(int id)
    //    {
    //        if (((DateTime.Now - LastChecked).TotalSeconds > 60) || !_cachedFilm.FilmId.Equals(id))
    //        {
    //            LastChecked = DateTime.Now;

    //            _cachedFilm = _inner.GetSelectedMovie(id);
    //        }

    //        return _cachedFilm;
    //    }
    //}
}