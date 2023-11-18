using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface ISSmapperRepository
    {
        Task<IEnumerable<Screen_Show_mapper>> GetSSmapperAsync();
      Task<Screen_Show_mapper> FindSSmapper(int id);
    }
}
