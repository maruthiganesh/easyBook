using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class ShowsRepository:IShowsRepository
    {
        private readonly DataContext dc;
      public ShowsRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Shows>> GetShowsAsync(){
        return await dc.Shows.ToListAsync();

      }
      public async Task<Shows> FindShows(int id){
        return await dc.Shows.FindAsync(id);
      }
    }
}
