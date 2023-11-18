using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class MoviesRepository:IMoviesRepository
    {

      private readonly DataContext dc;
      public MoviesRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Movies>> GetMoviesAsync(){
        return await dc.Movies.ToListAsync();

      }
      public async Task<Movies> FindMovies(int id){
        return await dc.Movies.FindAsync(id);
      }

    }
}
