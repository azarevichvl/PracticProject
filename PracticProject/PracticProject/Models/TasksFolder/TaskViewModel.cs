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
        public string Topic { get; set; }

        [Required]
        [Display(Name = "Полное описание")]
        public string Description { get; set; }

        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }

        [Required]
        [Display(Name = "Язык задания")]
        public int TaskLangId { get; set; }

        [Display(Name = "Язык ответа")]
        public int AnsLangId { get; set; }
    }
}