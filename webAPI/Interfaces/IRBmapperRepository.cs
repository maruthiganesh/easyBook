using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface IRBmapperRepository
    {
      Task<IEnumerable<Reservation_Bookedseats_mapper>> GetRBmapperAsync();
      Task<Reservation_Bookedseats_mapper> FindRBmapper(int id);

    }
}
