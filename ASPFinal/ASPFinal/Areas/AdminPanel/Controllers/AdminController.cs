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
    public class AdminController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Admin
        public ActionResult Index()
        {
            List<Admins> admins = context.Admins.ToList();
            return View(admins);
        }

        public ActionResult Create()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Create(Admins admins)
        {
            if (ModelState.IsValid)
            {
                context.Admins.Add(admins);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(admins);
        }


        public ActionResult Edit(int Id)
        {
            Admins admins = context.Admins.Find(Id);
            if (admins == null)
            {
                return HttpNotFound();
            }
            return View(admins);
        }

        [HttpPost]
        public ActionResult Edit(Admins admins)
        {
            if (ModelState.IsValid)
            {
                context.Entry(admins).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admins);
        }

        public ActionResult Delete(int Id)
        {
            Admins admins = context.Admins.Find(Id);
            if (admins == null)
            {
                return HttpNotFound();
            }

            context.Admins.Remove(admins);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}