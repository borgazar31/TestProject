using TaskManagement.Data.Interface;
using TaskManagement.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace TaskManagement.Pages.Task
{
    public class AddModel : PageModel
    {
        private readonly ITask _task;
        public Tasks task;
        public string idParent;

        public AddModel(ITask task)
        {
            _task = task;
        }

        public IActionResult OnPost(string name, string description, string listPerformers, int pLaborIntesity, string idParent)
        {    
            task = new Tasks()
            {
                Name = name,
                Description = description,
                ListPerformers = listPerformers,
                PLaborIntesity = pLaborIntesity,
                IdParent = Convert.ToInt32(idParent),
                DateRegistr = DateTime.Now,
                TaskStatus = "Назначена"
            };

            _task.AddTask(task);
            return RedirectToPage("./Index");
        }
        
        public void OnGet(int? id)
        {
            if (id != null)
                idParent = id.ToString();
        }
    }
}
