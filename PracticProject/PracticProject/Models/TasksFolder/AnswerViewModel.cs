using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.TasksFolder
{
    public class AnswerViewModel
    {
        public string Id{ get; set; }

        [Display(Name="Ответ")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 1000 символов")]
        public string Description { get; set; }
        public int TaskId { get; set; }
        public Task TaskItem { get; set; }
    }
}