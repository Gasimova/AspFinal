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
    public class FeaturesController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Features
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Features> features = context.Features.ToList();
            return View(features);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Features features)
        {
            if (ModelState.IsValid)
            {
                context.Features.Add(features);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(features);
        }

        public ActionResult Edit(int Id)
        {
            Features features = context.Features.Find(Id);
            if (features == null)
            {
                return HttpNotFound();
            }
            return View(features);
        }


        [HttpPost]
        public ActionResult Edit(Features features)
        {
            if (ModelState.IsValid)
            {
                context.Entry(features).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(features);
        }

        public ActionResult Delete(int Id)
        {
            Features features = context.Features.Find(Id);
            if (features == null)
            {
                return HttpNotFound();
            }
            context.Features.Remove(features);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}