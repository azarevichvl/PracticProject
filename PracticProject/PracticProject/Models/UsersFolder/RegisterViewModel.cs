using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PracticProject.Models.UsersFolder
{
    public class RegisterViewModel
    {
        /*
        [Required]
        [Display(Name = "Логин")]
         */ 
        public string UserName { get; set; }

        /*[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
         */ 
        public string Password { get; set; }

        /*[Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")] //--Doesn't work, why?
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
         */ 
        public string PasswordConfirm { get; set; }

        /*[Required]
        [Display(Name = "Запомнить?")]
         */ 
        public bool RememberMe { get; set; }

        //[Display(Name = "Имя")]
        public String Name { get; set; }

        /*
        [Required]
        [Display(Name = "Email")]
         */ 
        public String Adress { get; set; }
    }
}