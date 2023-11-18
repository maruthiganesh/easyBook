using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPI.Models
{
    public class User
    {
      [Key]
      public int User_id { get; set; }
      public string User_name { get; set; }
      public string User_mailId {get;set;}
      public string User_phoneNumber {get;set;}
      public string User_password {get;set;}
      public string User_location {get;set;}
      public string User_language {get;set;}

      public Reservations Reservation{get;set;}


    }
}
