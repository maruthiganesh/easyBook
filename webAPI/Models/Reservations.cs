using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Reservations
    {
        [Key]
        public int Reservation_id {get;set;}
        [ForeignKey("User")]
        public int User_id {get;set;}
        public User User{get;set;}
        [ForeignKey("Screen_Show_mapper")]
        public int SS_id {get;set;}
        public Screen_Show_mapper Screen_Show_Mapper {get;set;}
        public Reservation_Bookedseats_mapper Reservation_Bookedseats_Mapper {get;set;}
    }
}
