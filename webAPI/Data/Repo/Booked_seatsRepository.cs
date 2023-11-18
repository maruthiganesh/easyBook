using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class Booked_seatsRepository:IBooked_seatsRepository
    {
      private readonly DataContext dc;
      public Booked_seatsRepository(DataContext dc)
      {
        this.dc=dc;

      }
      public async Task<IEnumerable<Booked_seats>> GetBooked_seatsAsync(){
        return await dc.Booked_Seats.ToListAsync();

      }
      public async Task<Booked_seats> FindBooked_seats(int id){
        return await dc.Booked_Seats.FindAsync(id);
      }


    }
}
