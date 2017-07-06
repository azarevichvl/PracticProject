using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using PracticProject.Models;
using PracticProject.Models.UsersFolder;
using System.Data;

//JustCopy
namespace PracticProject.Controllers
{
    [Authorize(Roles = "admin, moderator, user")]
    public class UsersController : Controller
    {
        private PracticeDbContext db = new PracticeDbContext();

        [HttpGet]
        public ActionResult Index()
        {
            var users = db.Users.Include(u => u.RoleId).ToList();

            List<Role> roles = db.Roles.ToList();
            roles.Insert(0, new Role { Name = "Все", Id = 0 });
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            return View(users);
        }

        [HttpPost]
        public ActionResult Index(int? roleId)
        {
            if (roleId == 0 || roleId == null)
            {
                return RedirectToAction("Index");
            }

            IEnumerable<User> allUsers = from user in db.Users.Include(u => u.RoleId)
                                         where user.RoleId == roleId
                                         select user;

            List<Role> roles = db.Roles.ToList();
            roles.Insert(0, new Role { Name = "Все", Id = 0 });
            ViewBag.Roles = new SelectList(roles, "Id", "Name");

            return View(allUsers.ToList());
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            User user = db.Users.Find(id);
            if (id == null || user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            SelectList roles = new SelectList(db.Roles, "Id", "Name", user.RoleId);
            ViewBag.Roles = roles;

            return View(user);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            SelectList roles = new SelectList(db.Roles, "id", "Name");
            ViewBag.Roles = roles;

            return View(user);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            User user = db.Users.Find(id);

            if (id == null || user == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
