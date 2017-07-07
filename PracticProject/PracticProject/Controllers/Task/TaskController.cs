using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PracticProject.Models;

namespace PracticProject.Controllers.Task
{
    public class TaskController : Controller
    {
        public ActionResult AddTaskPage()
        {
            PracticeDbContext db = new PracticeDbContext();
            ViewBag.Languages = db.Languages;

            return View();
        }

    }
}
