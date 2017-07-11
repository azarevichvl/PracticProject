﻿using System;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.UsersFolder
{
    public class User
    {
        public int Id { get; set; }
        
        
        [Required]
        [Display(Name = "Логин")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        
        public string Login { get; set; }
        
        
        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(128, ErrorMessage = "Превышена максимальная длина записи")]
        
        public string Password { get; set; }
        public string Salt { get; set; }
        
        
        [Required]
        [Display(Name = "Статус")]
        
        public int RoleId { get; set; }

        
        [Display(Name = "Имя")]
        
        public string Name { get; set; }

        
        [Display(Name = "Почта")]
        
        public string Email { get; set; }

        
        [Display(Name = "Язык интерфейса")]
        
        public int InterfaceLanguagesId { get; set; }
        public Language LanguageInterface { get; set; }
        public int KnownLanguagesId { get; set; }
        public Language LanguageKnown { get; set; }
        public int LearningLanguagesId { get; set; }
        public Language LanguageLearning { get; set; }

       
       [Display(Name = "Доступно опубликовать задач")] 
    
        public int Count { get; set; }

    }
}