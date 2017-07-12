using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PracticProject.Models;
using PracticProject.Models.TasksFolder;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.TasksFolder
{
    public class Task
    {
        public int Id { get; set; }
        [Display(Name = "Дата публикации")]
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        [Display(Name = "Заголовок")]
        public string Title { get; set; }
        public string Description { get; set; }
        public int StatusId { get; set; }
        public byte[] Image { get; set; }
        public int TaskLanguageId { get; set; }

        [Display(Name = "Язык задания")]
        public PracticProject.Models.Language TaskLanguage { get; set; }
        public int AnswerLanguageId { get; set; }

        [Display(Name = "Язык ответа")]
        public Language AnswerLanguage { get; set; }
    }
}