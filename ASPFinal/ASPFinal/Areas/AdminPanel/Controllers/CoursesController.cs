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
    public class CoursesController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Courses
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Courses> courses = context.Courses.Include("Categories").ToList();
            return View(courses);
        }


        public ActionResult Create()
        {
            ViewBag.Categories = context.Categories.ToList();
            return View();
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Courses courses)
        {
            if (ModelState.IsValid)
            {
                if (courses.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(courses);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + courses.ImgFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                courses.ImgFile.SaveAs(imgPath);
                courses.Image = imgName;

                context.Courses.Add(courses);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(courses);
        }


        public ActionResult Edit(int Id)
        {
            Courses courses = context.Courses.Find(Id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = context.Categories.ToList();
            return View(courses);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Courses courses)
        {
            if (ModelState.IsValid)
            {
                Courses courses1 = context.Courses.Find(courses.Id);

                if (courses.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + courses.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), courses1.Image);
                    System.IO.File.Delete(oldPath);

                    courses.ImgFile.SaveAs(imgPath);
                    courses1.Image = imgName;
                }

                courses1.Tags = courses.Tags;
                courses1.Text = courses.Text;
                courses1.TextTitle = courses.TextTitle;

                context.Entry(courses1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(courses);
        }

        public ActionResult Delete(int Id)
        {
            Courses courses = context.Courses.Find(Id);
            if (courses == null)
            {
                return HttpNotFound();
            }
            context.Courses.Remove(courses);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}