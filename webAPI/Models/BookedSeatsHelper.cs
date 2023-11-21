using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class BookedSeatsHelper
    {
        public int User_id {get;set;}
        public int Screen_id {get;set;}
        public int[] Seat_id {get;set;}
        public DateTime Date_time {get;set;}
        
    }
}