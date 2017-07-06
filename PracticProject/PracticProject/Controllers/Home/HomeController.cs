using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticProject.Models;
using System.Data.Entity;

namespace PracticProject.Controllers
{
    public class HomeController : Controller
    {
        PracticeDbContext db = new PracticeDbContext();

        public ActionResult Index()
        {
            IEnumerable<Language> lang = db.Languages.Where(u => u.Name == "English");
            ViewBag.Languages = lang;

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
