using System;
using System.Collections.Generic;
using System.Linq;
using DMDWork.Data.Models;
using System.Threading.Tasks;

namespace DMDWork.Data.Interface
{
    public interface ITask
    {
        IEnumerable<Tasks> AllTask { get;  }
        IEnumerable<Childs> AllChild { get; }
        Tasks GetTask(int ID);
        void AddTask(Tasks task);
        void DelTask(int ID);
        void UpdateTask(Tasks task);
    }
}
