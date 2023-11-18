using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webAPI.Interfaces;
using webAPI.Models;

namespace webAPI.Data.Repo
{
    public class UserRepository:IUserRepository
    {

      private readonly DataContext dc;
      public UserRepository(DataContext dc){
          this.dc=dc;
      }

      public async Task<User> Authenticate(string user_mailId, string user_password){
            return await dc.Users.FirstOrDefaultAsync(x=> x.User_mailId == user_mailId && x.User_password== user_password);
      }

    }
}
