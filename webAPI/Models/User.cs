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
      public int user_id { get; set; }
      public string user_name { get; set; }
      public string user_mailId {get;set;}
      public string user_phoneNumber {get;set;}
      public string user_password {get;set;}


    }
}
