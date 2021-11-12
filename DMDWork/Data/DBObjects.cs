using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManagement.Data.Models
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            if (!content.Tasks.Any())
                content.Tasks.AddRange(new Tasks() {Name = "Sleep", DateRegistr = DateTime.Now, Description = "it's cool", ListPerformers = "Azar", PLaborIntesity = 2});
            content.SaveChanges();
            
            if (!content.Account.Any())
                content.Account.AddRange(new Account() { Login = "Borg", Email = "azar.borgoiakov@mail.ru", Password = BCrypt.Net.BCrypt.HashPassword("borg") });
            content.SaveChanges();
        }        
    }
}
