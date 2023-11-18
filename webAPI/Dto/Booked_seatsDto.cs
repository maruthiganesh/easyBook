using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Dto
{
    public class Booked_seatsDto
    {
        public int Seat_id {get;set;}
        public string Seat_name {get;set;}
        public DateTime Date_time {get;set;}

        public int Screen_id{get;set;}
       
        public int Fare_id {get;set;}
    }
}
