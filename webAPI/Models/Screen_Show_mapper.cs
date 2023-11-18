using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Screen_Show_mapper
    {
        [Key]
        public int SS_id {get;set;}
        [ForeignKey("Screens")]
        public int Screen_id {get;set;}
        public Screens Screens {get;set;}
        [ForeignKey("Shows")]
        public int Show_id {get;set;}
         public Shows Shows {get;set;}
        public Reservations Reservation {get;set;}

    }
}
