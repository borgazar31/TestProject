using DMDWork.Data.Interface;
using DMDWork.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace DMDWork.Pages.Task
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
