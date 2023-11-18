using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Shows
    {

      [Key]
      public int Show_id {get;set;}
      public string Show_time {get;set;}

      [ForeignKey("Movies")]
      public int Movie_id {get;set;}

      public Movies Movie {get;set;}
      public ICollection<Screen_Show_mapper> Screen_Show_Mapper{get;set;}


    }
}
