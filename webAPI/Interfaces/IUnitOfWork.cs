using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Data.Interfaces;

namespace webAPI.Interfaces
{
    public interface IUnitOfWork
    {
        ITheaterRepository TheaterRepository {get;}
        Task <bool> SaveAsync();
    }
}
