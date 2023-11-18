using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Movies
    {
      [Key]
        public int Movie_id {get;set;}
        public string Movie_name {get;set;}
        public string Genre {get;set;}
        public string Language {get;set;}
        public string Run_time {get;set;}
        public string Release_date {get;set;}

        public Shows Shows {get;set;}
    }
}
