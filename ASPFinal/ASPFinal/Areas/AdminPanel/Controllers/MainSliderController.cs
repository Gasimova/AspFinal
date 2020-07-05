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
    public class MainSliderController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/MainSlider
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<MainSlider> mainSliders = context.MainSliders.ToList();
            return View(mainSliders);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(MainSlider mainSlider)
        {
            if (ModelState.IsValid)
            {
                if (mainSlider.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(mainSlider);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + mainSlider.ImgFile.FileName;
                string imgPath =Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                mainSlider.ImgFile.SaveAs(imgPath);
                mainSlider.Image = imgName;

                context.MainSliders.Add(mainSlider);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(mainSlider);
        }

        public ActionResult Edit(int Id)
        {
            MainSlider mainSlider = context.MainSliders.Find(Id);
            if (mainSlider == null)
            {
                return HttpNotFound();
            }
            return View(mainSlider);
        }

        [HttpPost]
        public ActionResult Edit(MainSlider mainSlider)
        {
            if (ModelState.IsValid)
            {
                MainSlider mainSlider1 = context.MainSliders.Find(mainSlider.Id);

                if (mainSlider.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + mainSlider.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), mainSlider1.Image);
                    System.IO.File.Delete(oldPath);

                    mainSlider.ImgFile.SaveAs(imgPath);
                    mainSlider1.Image = imgName;
                }

                mainSlider1.Subtitle = mainSlider.Subtitle;
                mainSlider1.Title = mainSlider.Title;

                context.Entry(mainSlider1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(mainSlider);
        }

        public ActionResult Delete(int Id)
        {
            MainSlider mainSlider = context.MainSliders.Find(Id);
            if (mainSlider == null)
            {
                return HttpNotFound();
            }
            context.MainSliders.Remove(mainSlider);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}