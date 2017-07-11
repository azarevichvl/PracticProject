using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Configuration;
using System.Security.Cryptography;
using SHA3;
using PracticProject.Models;
using PracticProject.Models.UsersFolder;
using System.Text;
using System.Collections;


namespace PracticProject.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        PracticeDbContext db = new PracticeDbContext();

        public ActionResult Register()
        {
            ViewBag.InterfaceLanguageId = new SelectList(db.Languages, "Id", "Name");
            ViewBag.KnownLanguagesId = new SelectList(db.Languages, "Id", "Name");
            ViewBag.LearningLanguagesId = new SelectList(db.Languages, "Id", "Name");

            return View();
        }

        private string GenerateHash(string password, string salt)
        {
            SHA3Unmanaged sha3 = new SHA3Unmanaged(512);
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(password + salt + WebConfigurationManager.AppSettings["globalSalt"]);
            byte[] hash = sha3.ComputeHash(bytes);
            return ByteArrayToString(hash);
        }

        private string GenerateSalt()
        {
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            byte[] saltInBytes = new byte[12];
            crypto.GetBytes(saltInBytes);
            return ByteArrayToString(saltInBytes);
        }

        private static string ByteArrayToString(byte[] ba)
        {
            string hex = BitConverter.ToString(ba);
            return hex.Replace("-", "");
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!ValidateUser(model.UserName, null))
                {
                    string salt = GenerateSalt();
                    if (CreateUser(model, GenerateHash(model.Password, salt), salt))
                    {
                        return SetAuthCookie(model.UserName, model.RememberMe, returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Пользователь с данным логином уже существует");
                }
            }
            return View(model);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LogViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model.UserName, model.Password))
                {
                    return SetAuthCookie(model.UserName, model.RememberMe, returnUrl);
                }
                ModelState.AddModelError("", "Неправильный пароль или логин");
            }
            return View(model);
        }

        private ActionResult SetAuthCookie(string userName, bool rememberMe, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(userName, rememberMe);
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }

        private bool CreateUser(RegisterViewModel model, string password, string salt)
        {
            using (PracticeDbContext db = new PracticeDbContext())
            {
                try
                {
                    User newUser = new User
                    {
                        Login = model.UserName,
                        Password = password,
                        RoleId = 3,
                        Salt = salt,
                        Name = model.Name,
                        Email = model.Email,
                        Count = 10,
                        InterfaceLanguageId = model.InterfaceLanguageId,    
                        KnownLanguagesId = model.KnownLanguagesId,
                        LearningLanguagesId = model.LearningLanguagesId
                    };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                }
                catch
                {
                    return true;//false;
                }
            }
            return true;
        }

        protected bool ValidateUser(string login, string password)
        {
            bool isValid = false;

            try
            {
                IEnumerable<User> userList = db.Users.Where(u => u.Login == login);

                User user = userList.FirstOrDefault();

                if (user != null && password == null || user != null && Equals(user.Password, GenerateHash(password, user.Salt)))
                    isValid = true;
            }
            catch
            {
                isValid = false;
            }


            return isValid;
        }

    }
}
