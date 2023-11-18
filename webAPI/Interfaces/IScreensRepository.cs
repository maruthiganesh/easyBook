using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;

namespace webAPI.Interfaces
{
    public interface IScreensRepository
    {
        Task<IEnumerable<Screens>> GetScreensAsync();
      Task<Screens> FindScreens(int id);
    }
}
