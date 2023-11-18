using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface IBooked_seatsRepository
    {
         Task<IEnumerable<Booked_seats>> GetBooked_seatsAsync();
      Task<Booked_seats> FindBooked_seats(int id);
    }
}
