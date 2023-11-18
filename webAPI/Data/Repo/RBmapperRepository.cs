using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class RBmapperRepository:IRBmapperRepository
    {
        private readonly DataContext dc;
      public RBmapperRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Reservation_Bookedseats_mapper>> GetRBmapperAsync(){
        return await dc.Reservation_Bookedseats_Mappers.ToListAsync();

      }
      public async Task<Reservation_Bookedseats_mapper> FindRBmapper(int id){
        return await dc.Reservation_Bookedseats_Mappers.FindAsync(id);
      }
    }
}
