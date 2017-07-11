using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PracticProject.Models
{
    public class RegisterViewModel
    {
        
        [Required]
        [Display(Name = "Логин")]
         
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
         
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")] 
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
  
        public string PasswordConfirm { get; set; }


        [Display(Name = "Запомнить?")]
         
        public bool RememberMe { get; set; }

        [Display(Name = "Имя")]
        public String Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        public String Email { get; set; }

        public int InterfaceLanguagesId { get; set; }
        public Language LanguagesInterface { get; set; }

        public int Count { get; set; }
    }
}