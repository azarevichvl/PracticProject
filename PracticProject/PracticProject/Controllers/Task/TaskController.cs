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

        public ActionResult Details(int? id)
        {
            if (id == null) { id = 10; }
            var task = db.Tasks.Include(p => p.TaskLanguage).Include(p => p.AnswerLanguage).FirstOrDefault(p => p.Id == id); 
            return View(task);
        }

        [ChildActionOnly]
        public ActionResult TaskListView()
        {
            var task = db.Tasks.Include(p => p.TaskLanguage).Include(p => p.AnswerLanguage); 
            return PartialView(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTaskPage([Bind(Include = "Id,Date,UserId,Title,Description,StatusId,Image,TaskLanguageId,AnswerLanguageId")] PracticProject.Models.TasksFolder.Task task)
        {
            if (ModelState.IsValid)
            {
                task.Date = DateTime.Today;
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = task.Id });
            }

            return View(); // Error
        }

    }
}
