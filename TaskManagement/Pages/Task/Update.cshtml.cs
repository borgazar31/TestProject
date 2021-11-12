using TaskManagement.Data.Interface;
using TaskManagement.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Linq;

namespace TaskManagement.Pages.Task
{
    public class UpdateModel : PageModel
    {
        private readonly ITask _task;
        public Tasks UpTask;
        public int IdTask;

        public UpdateModel(ITask itask)
        {
            _task = itask;
        }

        public IActionResult OnPost(int id, string name, string description, string listPerformers, int pLaborIntesity, string taskStatus, string idParent)
        {
            Tasks task = _task.GetTask(id);
            task.Name = name;
            task.Description = description;
            task.ListPerformers = listPerformers;
            task.PLaborIntesity = pLaborIntesity;
            task.IdParent = Convert.ToInt32(idParent);
            task.TaskStatus = taskStatus;

            //���� ������ ���������, �� ����������� �� ���� ��������� � ����� ����������
            if (taskStatus == "���������")
            {
                task.DateComplete = DateTime.Now;
                task.FExecutionTime = UpdateChild(task);
            }    

            _task.UpdateTask(task);
            return RedirectToPage("./Index");
        }
        
        public void OnGet(int id)
        {
            UpTask = _task.GetTask(id);
            IdTask = id;
        }

        private TimeSpan UpdateChild(Tasks tasks)
        {
            //���� ���� ���������, �� ������ �� ������� �� "���������", ���������� ���� ���������� � ����� ����������.

            if (tasks.IdChild == null)
                return tasks.DateComplete - tasks.DateRegistr;
            else
            {
                Childs child = _task.AllChild.ToList().Find(a => a.ID == tasks.ID);

                foreach (var a in child.Child)
                {
                    if (a.TaskStatus != "���������")
                    {
                        a.TaskStatus = "���������";
                        a.DateComplete = DateTime.Now;
                        a.FExecutionTime = UpdateChild(a);
                        _task.UpdateTask(a);
                    }

                    tasks.FExecutionTime = a.FExecutionTime;
                }

                return tasks.FExecutionTime;

            }
            
        }
    }
}
