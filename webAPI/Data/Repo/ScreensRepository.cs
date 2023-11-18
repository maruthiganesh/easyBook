using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class ScreensRepository:IScreensRepository
    {
        private readonly DataContext dc;
      public ScreensRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Screens>> GetScreensAsync(){
        return await dc.Screens.ToListAsync();

      }
      public async Task<Screens> FindScreens(int id){
        return await dc.Screens.FindAsync(id);
      }
    }
}
