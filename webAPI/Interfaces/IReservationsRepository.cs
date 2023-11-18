using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface IReservationsRepository
    {
      Task<IEnumerable<Reservations>> GetReservationsAsync();
      Task<Reservations> FindReservations(int id);

    }
}
