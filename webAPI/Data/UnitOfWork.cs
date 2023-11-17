using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Data.Interfaces;
using webAPI.Data.Repo;
using webAPI.Interfaces;

namespace webAPI.Data
{
    public class UnitOfWork:IUnitOfWork
    {
      private readonly DataContext dc;
      public UnitOfWork(DataContext dc){
          this.dc=dc;
      }
        public ITheaterRepository TheaterRepository =>
        new TheaterRepository(dc);

        public async Task<bool> SaveAsync(){
            return await dc.SaveChangesAsync()>0;
        }
    }
}
