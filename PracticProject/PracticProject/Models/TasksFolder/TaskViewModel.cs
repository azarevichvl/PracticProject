using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.TasksFolder
{
    public class TaskViewModel
    {
        [Required]
        [Display(Name = "Заголовок")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Полное описание")]
        public string Description { get; set; }

        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Язык задания")]
        public int TaskLanguageId { get; set; }

        public Language TaskLanguage { get; set; }

        [Display(Name = "Язык ответа")]
        public int AnswerLangId { get; set; }

        public Language AnswerLanguage { get; set; }

    }
}