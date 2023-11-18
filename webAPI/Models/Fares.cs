using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Fares
    {
        [Key]
        public int Fare_id{get;set;}
        public string Class_name {get;set;}
        public int Price{get;set;}

        [ForeignKey("Shows")]
        public int Show_id{get;set;}
        public Shows Show {get;set;}
        public ICollection<Booked_seats> Booked_Seats{get;set;}
    }
}
