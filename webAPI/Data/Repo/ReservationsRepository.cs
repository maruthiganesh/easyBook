using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class ReservationsRepository:IReservationsRepository
    {
        private readonly DataContext dc;
      public ReservationsRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Reservations>> GetReservationsAsync(){
        return await dc.Reservations.ToListAsync();

      }
      public async Task<Reservations> FindReservations(int id){
        return await dc.Reservations.FindAsync(id);
      }
    }
}
