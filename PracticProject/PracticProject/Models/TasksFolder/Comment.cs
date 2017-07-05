using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PracticProject.Models.TasksFolder
{
    public class Comment
    {
        public int Id { get; set; }
        public int TastId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
    }
}