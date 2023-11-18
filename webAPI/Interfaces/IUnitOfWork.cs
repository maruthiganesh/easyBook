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
        IMoviesRepository MoviesRepository {get;}
        IUserRepository UserRepository {get;}
        IBooked_seatsRepository Booked_seatsRepository {get;}
        IFaresRepository FaresRepository {get;}
        IRBmapperRepository RBmapperRepository {get;}
        IReservationsRepository ReservationsRepository {get;}
        ISSmapperRepository SSmapperRepository {get;}
        IScreensRepository ScreensRepository {get;}
        IShowsRepository ShowsRepository {get;}

        Task <bool> SaveAsync();
    }
}
