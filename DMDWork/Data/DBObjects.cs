using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMDWork.Data.Models
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {

            if (!content.Tasks.Any())
                content.Tasks.AddRange(
                        new Tasks {Name = "DMDTestWork", Description = "Create ASP.NET Core project", ListPerformers = "Azar", DateRegistr = new DateTime(2021, 09, 30), TaskStatus = "Выполняется", PLaborIntesity = 7 * 24, IdChild = "2" },
                        new Tasks {Name = "InterfaceProject", Description = "Create nice interface", ListPerformers = "Azar", DateRegistr = new DateTime(2021, 10, 05), TaskStatus = "Выполняется", PLaborIntesity = 24, IdParent = 1 },
                        new Tasks {Name = "Sleep", Description = "It's good", ListPerformers = "Azar", DateRegistr = new DateTime(2021, 10, 05), TaskStatus = "Назначена", PLaborIntesity = 8 }
                        );

            content.SaveChanges();
        }        
    }
}
