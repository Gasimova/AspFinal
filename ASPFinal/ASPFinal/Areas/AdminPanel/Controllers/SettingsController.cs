using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Areas.AdminPanel.Controllers
{
    public class SettingsController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Settings
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Settings> settings = context.Settings.ToList();
            return View(settings);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Settings settings)
        {
            if (ModelState.IsValid)
            {
                if (settings.LogoFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(settings);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + settings.LogoFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                settings.LogoFile.SaveAs(imgPath);
                settings.Logo = imgName;

                context.Settings.Add(settings);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(settings);
        }

        public ActionResult Edit(int Id)
        {
            Settings settings = context.Settings.Find(Id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            return View(settings);
        }

        [HttpPost]
        public ActionResult Edit(Settings settings)
        {
            if (ModelState.IsValid)
            {
                Settings settings1 = context.Settings.Find(settings.Id);

                if (settings.LogoFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + settings.LogoFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), settings1.Logo);
                    System.IO.File.Delete(oldPath);

                    settings.LogoFile.SaveAs(imgPath);
                    settings1.Logo = imgName;
                }

              

                context.Entry(settings1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(settings);
        }

        public ActionResult Delete(int Id)
        {
            Settings settings = context.Settings.Find(Id);
            if (settings == null)
            {
                return HttpNotFound();
            }
            context.Settings.Remove(settings);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}