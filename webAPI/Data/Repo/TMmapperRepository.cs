using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class TMmapperRepository:ITMmapperRepository
    {
      private readonly DataContext dc;
      public TMmapperRepository(DataContext dc)
      {
        this.dc=dc;

      }
        public async Task <IEnumerable<Theater_Movie_mapper>> GetTMmapperAsync(){
          return await dc.Theater_Movie_Mappers.ToListAsync();
        }
        public async  Task<Theater_Movie_mapper> FindTMmapper(int id){
          return await dc.Theater_Movie_Mappers.FindAsync(id);
        }

        public async Task <List<int>> FindMovieIDs(List<int> theater_ids){
          var data= await dc.Theater_Movie_Mappers
                        .Where(x=> theater_ids.Any(tid => tid == x.Theater_id))
                        .Select(x=> x.Movie_id)
                        .ToListAsync();
          return data;

        }

    }
}