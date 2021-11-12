using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Data.Models;

namespace TaskManagement.Data
{
    public class AppDBContent : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Tasks> Tasks { get; set; }

        public AppDBContent(DbContextOptions<AppDBContent> option) : base(option)
        {
            //Database.EnsureCreated();
        }      
    }
}
