using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Booked_seats
    {
          [Key]
        public int Seat_id {get;set;}
        public string Seat_name {get;set;}
        public DateTime Date_time {get;set;}
        [ForeignKey("Screens")]
        public int Screen_id{get;set;}
        public Screens Screen {get;set;}
        [ForeignKey("Fares")]
        public int Fare_id {get;set;}
        public Fares Fare {get;set;}
        public Reservation_Bookedseats_mapper Reservation_Bookedseats_Mapper {get;set;}
    }
}
