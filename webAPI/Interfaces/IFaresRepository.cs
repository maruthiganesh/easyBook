using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface IFaresRepository
    {
      Task<IEnumerable<Fares>> GetFaresAsync();
      Task<Fares> FindFares(int id);

    }
}
