using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Dto
{
    public class MoviesDto
    {
        public int Movie_id {get;set;}
        public string Movie_name {get;set;}
        public string Genre {get;set;}
        public string Language {get;set;}
        public string Run_time {get;set;}
        public string Release_date {get;set;}

    }
}
