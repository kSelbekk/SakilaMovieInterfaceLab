using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SakilaMovieInterfaceLab.Data;

namespace SakilaMovieInterfaceLab.Services
{
    public interface IMovieRepository
    {
        public IQueryable<Film> GetAllMovies();

        public Film GetSelectedMovie(int id);
    }
}