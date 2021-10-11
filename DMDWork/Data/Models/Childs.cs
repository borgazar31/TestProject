using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMDWork.Data.Models
{
    //Childs содержит ID задачи и список подзадач.
    public class Childs
    {
        public int ID { get; set; }
        public List<Tasks> Child { get; set; }
    }
}
