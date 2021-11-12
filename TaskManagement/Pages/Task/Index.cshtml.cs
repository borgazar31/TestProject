using TaskManagement.Data.Interface;
using TaskManagement.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagement.Pages.Task
{
    public class IndexModel : PageModel
    {
        private readonly ITask _task;
        public List<Tasks> tasks = new List<Tasks>();
        public List<Childs> childs = new List<Childs>();
        public Tasks task;
        public Childs child;

        public IndexModel(ITask itask)
        {
            _task = itask;
            //task = _task.GetTask(2);
            //task.IdChild = "3";
            //_task.UpdateTask(task);
            childs = _task.AllChild.ToList();
            tasks = _task.AllTask.ToList();
        }

        public void OnGet(int? id)
        {
            if (id != null)
            {
                child = new Childs();
                child = childs.Find(a => a.ID == id);
                task = new Tasks();
                task = tasks.Find(a => a.ID == id);
            }
        }  
    }
}
