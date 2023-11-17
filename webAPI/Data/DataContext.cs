using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using webAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace webAPI.Data
{
    public class DataContext : DbContext
    {

          public DataContext(DbContextOptions<DataContext> options): base(options)
          {


          }
          public DbSet <Theater> Theaters {get;set;}
          public DbSet <User> Users {get;set;}
    }
}


