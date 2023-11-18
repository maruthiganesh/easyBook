using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class FaresRepository:IFaresRepository
    {
      private readonly DataContext dc;
      public FaresRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Fares>> GetFaresAsync(){
        return await dc.Fares.ToListAsync();

      }
      public async Task<Fares> FindFares(int id){
        return await dc.Fares.FindAsync(id);
      }

    }
}
