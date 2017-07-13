using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.TasksFolder
{
    public class Answer
    {
        public int Id { get; set; }
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 1000 символов")] //Знаю, чтотакое делать нельзя,но я не знаю, почему у меня передаётся Answer, а не AnswerViewModel
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public byte[] Image { get; set; }
        public int likes { get; set; }
        public int TaskId { get; set; }
        public Task TaskItem { get; set; }
    }
}