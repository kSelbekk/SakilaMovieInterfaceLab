using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.Services
{
    public interface IMovieRepository
    {
        public IEnumerable<Film> GetAllMovies();

        public Film GetSelectedMovie(int id);
    }

    public class MovieRepository : IMovieRepository
    {
        private readonly sakilaContext _sakilaContext;

        public MovieRepository(sakilaContext sakilaContext)
        {
            _sakilaContext = sakilaContext;
        }

        public IEnumerable<Film> GetAllMovies()
        {
            return _sakilaContext.Films;
        }

        public Film GetSelectedMovie(int id)
        {
            return _sakilaContext.Films.FirstOrDefault(i => i.FilmId == id);
        }
    }
}