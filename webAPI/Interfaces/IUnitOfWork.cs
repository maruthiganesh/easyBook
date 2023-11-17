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
        IUserRepository UserRepository {get;}
        Task <bool> SaveAsync();
    }
}
