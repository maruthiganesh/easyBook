using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Reservation_Bookedseats_mapper
    {
        [Key]
        public int RB_id {get;set;}

        [ForeignKey("Reservations")]
        public int Reservation_id{get;set;}
        public Reservations Reservation {get;set;}

        [ForeignKey("Booked_seats")]
        public int Seat_id {get;set;}
        public Booked_seats Book_seat {get;set;}
    }
}
