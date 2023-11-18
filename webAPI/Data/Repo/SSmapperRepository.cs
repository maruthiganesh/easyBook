using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class SSmapperRepository:ISSmapperRepository
    {
        private readonly DataContext dc;
      public SSmapperRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Screen_Show_mapper>> GetSSmapperAsync(){
        return await dc.Screen_Show_Mappers.ToListAsync();

      }
      public async Task<Screen_Show_mapper> FindSSmapper(int id){
        return await dc.Screen_Show_Mappers.FindAsync(id);
      }
    }
}
