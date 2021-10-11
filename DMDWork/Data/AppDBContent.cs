using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DMDWork.Data.Models;

namespace DMDWork.Data
{
    public class AppDBContent : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }

        public AppDBContent(DbContextOptions<AppDBContent> option) : base(option)
        {
            Database.EnsureCreated();
        }      
    }
}
