using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PracticProject.Models;
using PracticProject.Models.TasksFolder;

namespace PracticProject.Controllers.Task
{
    public class TaskController : Controller
    {
        PracticeDbContext db = new PracticeDbContext();
        public ActionResult AddTaskPage()
        {
            
            ViewBag.TaskLanguageId = new SelectList(db.Languages, "Id", "Name");
            ViewBag.AnswerLanguageId = new SelectList(db.Languages, "Id", "Name");

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTaskPage([Bind(Include = "Id,Date,UserId,Title,Description,StatusId,Image,TaskLanguageId,AnswerLanguageId")] PracticProject.Models.TasksFolder.Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            /*
            ViewBag.ManufacturerId = new SelectList(db.Manufacturers, "Id", "Name", printer.ManufacturerId);
            ViewBag.TypeId = new SelectList(db.Types, "Id", "Name", printer.TypeId);
            return View(printer);
             */
            return View(); // Error
        }

    }
}
