using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Areas.AdminPanel.Controllers
{
    public class UsersController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Users
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Users> users = context.Users.ToList();
            return View(users);
        }


        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Users users)
        {
            if (ModelState.IsValid)
            {
                context.Users.Add(users);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(users);
        }

        public ActionResult Edit(int Id)
        {
            Users users = context.Users.Find(Id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        [HttpPost]
        public ActionResult Edit(Users users)
        {
            if (ModelState.IsValid)
            {
                context.Entry(users).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        public ActionResult Delete(int Id)
        {
            Users users = context.Users.Find(Id);
            if (users == null)
            {
                return HttpNotFound();
            }

            context.Users.Remove(users);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}