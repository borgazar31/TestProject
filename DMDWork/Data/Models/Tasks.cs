﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagement.Data.Models
{
    public class Tasks
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ListPerformers { get; set; }
        public DateTime DateRegistr { get; set; }
        public string TaskStatus { get; set; }
        public float PLaborIntesity { get; set; }
        public TimeSpan FExecutionTime { get; set; }
        public DateTime DateComplete { get; set; }
        public int IdParent { get; set; }
        public string IdChild { get; set; }
    }
}
