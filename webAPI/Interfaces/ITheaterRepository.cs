using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
namespace webAPI.Data.Interfaces
{
    public interface ITheaterRepository
    {
      Task<IEnumerable<Theater>> GetTheatersAsync();
      Task<Theater> FindTheater(int id);


    }
}
