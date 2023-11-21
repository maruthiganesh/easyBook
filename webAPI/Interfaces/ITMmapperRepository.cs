using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface ITMmapperRepository
    {
        Task<IEnumerable<Theater_Movie_mapper>> GetTMmapperAsync();
         Task<Theater_Movie_mapper> FindTMmapper(int id);

         Task <List<int>> FindMovieIDs(List<int> theater_ids);
    }
}