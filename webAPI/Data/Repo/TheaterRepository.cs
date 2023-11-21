using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Models;
using webAPI.Data.Interfaces;
namespace webAPI.Data.Repo
{
    public class TheaterRepository:ITheaterRepository
    {
      private readonly DataContext dc;
      public TheaterRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Theater>> GetTheatersAsync(){
        return await dc.Theaters.ToListAsync();

      }
      public async Task<Theater> FindTheater(int id){
        return await dc.Theaters.FindAsync(id);
      }

      public async Task<List<int>> FindTheaterIDs(string[] locations)
      {
        var data= await dc.Theaters
                        .Where(x=> locations.Any(loc => loc == x.Theater_location))
                        .Select(x=> x.Theater_id)
                        .ToListAsync();
        return data;

      }

    }
}
