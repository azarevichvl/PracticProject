using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.TasksFolder
{
    public class Task
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public byte[] Image { get; set; }
        public int TaskLanguageId { get; set; }
        public int AnswerLanguageId { get; set; }
    }
}