using DMDWork.Data.Interface;
using DMDWork.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace DMDWork.Pages.Task
{
    public class DeleteModel : PageModel
    {
        private readonly ITask _task;
        public Tasks task { get; set; }
        public DeleteModel(ITask task)
        {
            _task = task;
        }

        public IActionResult OnGet(int id)
        {
            task = _task.GetTask(id);
            if ((task != null) && (task.IdChild == null))
            {
                //���� � ������ �������� ����������, �� �� �������� ������������ ������(���) ��������
                //��������� ��� ��������� ��������� � ��������� ������ �������� ��������
                if (task.IdParent == 0)
                    _task.DelTask(task.ID);
                else
                {
                    Tasks parent = _task.GetTask(task.IdParent);
                    parent.PLaborIntesity -= task.PLaborIntesity;
                    Childs childsParent = _task.AllChild.ToList().Find(a => a.ID == task.IdParent);
                    childsParent.Child.Remove(task);
                    parent.IdChild = null;
                    
                    foreach (var a in childsParent.Child)
                        parent.IdChild += $"{a.ID} ";

                    _task.DelTask(task.ID);
                }

                task = null;
            }
            return RedirectToPage("./Index");
        }
    }
}
