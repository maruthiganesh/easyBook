using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace webAPI.Data
{
    public class DataContext : DbContext
    {

          public DataContext(DbContextOptions<DataContext> options): base(options)
          {


          }

          public DbSet <Booked_seats> Booked_Seats {get;set;}
          public DbSet <Fares> Fares {get;set;}
          public DbSet <Movies> Movies {get;set;}
          public DbSet <Reservation_Bookedseats_mapper> Reservation_Bookedseats_Mappers {get;set;}
          public DbSet <Reservations> Reservations {get;set;}
          public DbSet <Screen_Show_mapper> Screen_Show_Mappers {get;set;}
          public DbSet <Screens> Screens {get;set;}
          public DbSet <Shows> Shows {get;set;}
          public DbSet <Theater> Theaters {get;set;}
          public DbSet <User> Users {get;set;}


          protected override void OnModelCreating(ModelBuilder modelBuilder)
          {
              modelBuilder.Entity<Reservation_Bookedseats_mapper>()
                  .HasKey(rb => rb.RB_id);

              modelBuilder.Entity<Reservation_Bookedseats_mapper>()
                  .HasOne(rb => rb.Reservation)
                  .WithOne(r => r.Reservation_Bookedseats_Mapper)
                  .HasForeignKey<Reservation_Bookedseats_mapper>(rb => rb.Reservation_id);

              modelBuilder.Entity<Reservation_Bookedseats_mapper>()
                  .HasOne(rb => rb.Book_seat)
                  .WithOne(bs => bs.Reservation_Bookedseats_Mapper)
                  .HasForeignKey<Reservation_Bookedseats_mapper>(rb => rb.Seat_id);

              modelBuilder.Entity<Movies>()
                  .HasOne(m => m.Shows)
                  .WithOne(s => s.Movie)
                  .HasForeignKey<Shows>(s => s.Movie_id);

               modelBuilder.Entity<Reservations>()
                  .HasOne(r => r.Screen_Show_Mapper)
                  .WithOne(ssm => ssm.Reservation)
                  .HasForeignKey<Screen_Show_mapper>(ssm => ssm.SS_id);

               modelBuilder.Entity<Booked_seats>()
                  .HasKey(bs => bs.Seat_id);

            modelBuilder.Entity<Booked_seats>()
                .HasOne(bs => bs.Screen)
                .WithMany(s => s.Booked_Seats)
                .HasForeignKey(bs => bs.Screen_id);

            modelBuilder.Entity<Booked_seats>()
                .HasOne(bs => bs.Fare)
                .WithMany()
                .HasForeignKey(bs => bs.Fare_id);

            modelBuilder.Entity<Fares>()
                .HasKey(f => f.Fare_id);

            modelBuilder.Entity<Fares>()
                .HasOne(f => f.Show)
                .WithMany()
                .HasForeignKey(f => f.Show_id);

                      base.OnModelCreating(modelBuilder);
                }

    }
}


