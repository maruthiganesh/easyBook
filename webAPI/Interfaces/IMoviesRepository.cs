using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
namespace webAPI.Interfaces
{
    public interface IMoviesRepository
    {
        Task<IEnumerable<Movies>> GetMoviesAsync();
      Task<Movies> FindMovies(int id);

      Task<IEnumerable<Movies>> FindMoviesList(List<int> Movie_ids);
    }
}
