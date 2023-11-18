using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface IShowsRepository
    {
      Task<IEnumerable<Shows>> GetShowsAsync();
      Task<Shows> FindShows(int id);

    }
}
