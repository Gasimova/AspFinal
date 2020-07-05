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
    public class CategoriesController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Categories
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Categories> categories = context.Categories.ToList();
            return View(categories);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Add(categories);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(categories);
        }

        public ActionResult Edit(int Id)
        {
            Categories categories = context.Categories.Find(Id);
            if (categories == null)
            {
                return HttpNotFound();
            }
            return View(categories);
        }

        [HttpPost]
        public ActionResult Edit(Categories categories)
        {
            if (ModelState.IsValid)
            {
                context.Entry(categories).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categories);
        }

        public ActionResult Delete(int Id)
        {
            Categories categories = context.Categories.Find(Id);
            if (categories == null)
            {
                return HttpNotFound();
            }

            context.Categories.Remove(categories);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}