using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Data.Interfaces;
using webAPI.Data.Repo;
using webAPI.Interfaces;

namespace webAPI.Data
{
    public class UnitOfWork:IUnitOfWork
    {
      private readonly DataContext dc;
      public UnitOfWork(DataContext dc){
          this.dc=dc;
      }
        public ITheaterRepository TheaterRepository =>
        new TheaterRepository(dc);

        public IMoviesRepository MoviesRepository =>
        new MoviesRepository(dc);
        public IBooked_seatsRepository Booked_seatsRepository =>
        new Booked_seatsRepository(dc);

        public IUserRepository UserRepository =>
        new UserRepository(dc);

        public IFaresRepository FaresRepository =>
        new FaresRepository(dc);

        public IRBmapperRepository RBmapperRepository =>
        new RBmapperRepository(dc);

        public IReservationsRepository ReservationsRepository =>
        new ReservationsRepository(dc);

        public ISSmapperRepository SSmapperRepository =>
        new SSmapperRepository(dc);

        public IScreensRepository ScreensRepository =>
        new ScreensRepository(dc);

        public IShowsRepository ShowsRepository =>
        new ShowsRepository(dc);



        public async Task<bool> SaveAsync(){
            return await dc.SaveChangesAsync()>0;
        }
    }
}
