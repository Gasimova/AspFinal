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
    public class TagsController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Tags
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Tags> tags = context.Tags.Include("Courses").ToList();
            return View(tags);
        }

        public ActionResult Create()
        {
            ViewBag.Courses = context.Courses.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Tags tags)
        {
            if (ModelState.IsValid)
            {
                context.Tags.Add(tags);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tags);
        }

        public ActionResult Edit(int Id)
        {
            Tags tags = context.Tags.Find(Id);
            if (tags == null)
            {
                return HttpNotFound();
            }
            ViewBag.Courses = context.Courses.ToList();
            return View(tags);
        }

        [HttpPost]
        public ActionResult Edit(Tags tags)
        {
            if (ModelState.IsValid)
            {
                context.Entry(tags).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tags);
        }

        public ActionResult Delete(int Id)
        {
            Tags tags = context.Tags.Find(Id);
            if (tags == null)
            {
                return HttpNotFound();
            }

            context.Tags.Remove(tags);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}