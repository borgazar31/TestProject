using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DMDWork.Data.Interface;
using DMDWork.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DMDWork.Data.Repository
{
    public class Repository : ITask
    {
        private readonly AppDBContent appDBContent;

        public Repository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        
        public IEnumerable<Tasks> AllTask => appDBContent.Tasks;

        public IEnumerable<Childs> AllChild => GetChild();

        //Создает список из Childs, которые имеют подзадачи
        public IEnumerable<Childs> GetChild()
        {
            List<Childs> childs = new List<Childs>();
            List<Tasks> tasks = AllTask.ToList();
            List<Tasks> childTasks;

            //Перебирает все задачи, если есть подзадачи, создает новый объект Childs            

            foreach (var a in AllTask)
            {
                if (a.IdChild == null)
                    continue;
                string[] idChilds = a.IdChild.Split(' ');
                Childs child = new Childs() { ID = a.ID};
                childTasks = new List<Tasks>();

                foreach (var i in idChilds)
                {                   
                    Tasks task = tasks.Find(a => a.ID == int.Parse(i));
                    childTasks.Add(task);
                }
                child.Child = childTasks;
                childs.Add(child);
                
            }

            return childs;
        }


        public void AddTask(Tasks task)
        {
            appDBContent.Tasks.Add(task);
            appDBContent.SaveChanges();

            //Если это подзадача, то добавляем в список подзадач родителя
            if (task.IdParent != 0)
            { 
                task = appDBContent.Tasks.FirstOrDefault(a => a.DateRegistr == task.DateRegistr);
                Tasks parentTask = appDBContent.Tasks.FirstOrDefault(a => a.ID == task.IdParent);
                parentTask.IdChild += $"{task.ID} ";
                UpdateTask(parentTask);
            }
            
        }

        public void DelTask(int ID)
        {
            appDBContent.Tasks.Remove(GetTask(ID));
            appDBContent.SaveChanges();
        }

        public Tasks GetTask(int ID) => appDBContent.Tasks.FirstOrDefault(a => a.ID == ID);


        public void UpdateTask(Tasks task)
        {
            Tasks oldTask = GetTask(task.ID);
            appDBContent.Tasks.Update(task);
            appDBContent.SaveChanges();

            //если изменили ID родителя, то изменяем список подзадач родителей
            if (task.IdParent != oldTask.IdParent)
            {
                if ((oldTask.IdParent != 0) & (task.IdParent == 0))
                {
                    Tasks parentTask = appDBContent.Tasks.FirstOrDefault(a => a.ID == oldTask.IdParent);
                    Childs childsParent = AllChild.ToList().Find(a => a.ID == oldTask.IdParent);
                    childsParent.Child.Remove(task);

                    foreach (var a in childsParent.Child)
                        parentTask.IdChild += $"{a.ID} ";

                    UpdateTask(parentTask);
                }
                else if ((oldTask.IdParent == 0) & (task.IdParent != 0))
                {
                    Tasks parentTask = appDBContent.Tasks.FirstOrDefault(a => a.ID == task.IdParent);
                    parentTask.IdChild += $"{task.ID} ";
                    UpdateTask(parentTask);
                }
                else
                {
                    Tasks oldparentTask = appDBContent.Tasks.FirstOrDefault(a => a.ID == oldTask.IdParent);
                    Childs childsParent = AllChild.ToList().Find(a => a.ID == oldTask.IdParent);
                    childsParent.Child.Remove(task);

                    foreach (var a in childsParent.Child)
                        oldparentTask.IdChild += $"{a.ID} ";

                    UpdateTask(oldparentTask);
                    Tasks parentTask = appDBContent.Tasks.FirstOrDefault(a => a.ID == task.IdParent);
                    parentTask.IdChild += $"{task.ID} ";
                    UpdateTask(parentTask);
                }
            }
        }
    }
}
