using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticProject.Models.TasksFolder
{
    public class Answer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public int likes { get; set; }
        public int TaskId { get; set; }
    }
}