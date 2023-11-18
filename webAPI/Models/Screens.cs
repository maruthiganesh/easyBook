using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class Screens
    {
      [Key]
      public int Screen_id { get; set; }
      public string Screen_name {get;set;}
      [ForeignKey("Theater")]
      public int Theater_id {get;set;}

      public Theater Theater {get;set;}
      public ICollection<Screen_Show_mapper> Screen_Show_Mapper{get;set;}
      public ICollection<Booked_seats> Booked_Seats {get;set;}





   }
}
