using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace webAPI.Models
{
    public class Theater
    {
        [Key]
        public int Theater_id { get; set; }
        public string Theater_name { get; set; }
        // public string Screen_ids { get; set; }
        public string Theater_location { get; set; }
        // public string Movies {get;set;}
        public ICollection<Screens> Screens {get;set;}
        public Theater_Movie_mapper Theater_Movie_Mapper {get;set;}

    }
}
