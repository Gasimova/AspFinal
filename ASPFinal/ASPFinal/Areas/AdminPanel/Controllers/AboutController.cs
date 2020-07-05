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
    public class AboutController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/About
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<About> abouts = context.Abouts.ToList();
            return View(abouts);

        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(About about)
        {
            if (ModelState.IsValid)
            {
                if (about.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(about);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImgFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                about.ImgFile.SaveAs(imgPath);
                about.Image = imgName;

                context.Abouts.Add(about);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(about);
        }

        public ActionResult Edit(int Id)
        {
            About about = context.Abouts.Find(Id);
            if (about==null)
            {
                return HttpNotFound();
            }
            return View(about);
        }

        [HttpPost]
        public ActionResult Edit(About about)
        {
            if (ModelState.IsValid)
            {
                About about1 = context.Abouts.Find(about.Id);

                if (about.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + about.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), about1.Image);
                    System.IO.File.Delete(oldPath);

                    about.ImgFile.SaveAs(imgPath);
                    about1.Image = imgName;
                }

                about1.Text = about.Text;
                about1.Video = about.Video;
                about1.ContentTitle = about.ContentTitle;

                context.Entry(about1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(about);
        }

        public ActionResult Delete(int Id)
        {
            About about = context.Abouts.Find(Id);
            if (about == null)
            {
                return HttpNotFound();
            }
            context.Abouts.Remove(about);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}