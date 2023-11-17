using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
namespace webAPI.Interfaces
{
    public interface IUserRepository
    {
        Task <User> Authenticate(string user_mailId, string user_password);
    }
}
