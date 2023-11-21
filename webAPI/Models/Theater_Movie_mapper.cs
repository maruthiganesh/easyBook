using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Theater_Movie_mapper
    {

      [Key]
       public int TM_id {get;set;}
      [ForeignKey("Theater")]
       public int Theater_id{get;set;}
       public Theater Theater {get;set;}

       [ForeignKey("Movies")]
       public int Movie_id {get;set;}
       public Movies Movies {get;set;}
    }
}