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
    public class SpeakersController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Speakers
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Speakers> speakers = context.Speakers.ToList();
            return View(speakers);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Speakers speakers)
        {
            if (ModelState.IsValid)
            {
                if (speakers.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(speakers);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speakers.ImgFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                speakers.ImgFile.SaveAs(imgPath);
                speakers.Image = imgName;

                context.Speakers.Add(speakers);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(speakers);
        }

        public ActionResult Edit(int Id)
        {
            Speakers speakers = context.Speakers.Find(Id);
            if (speakers == null)
            {
                return HttpNotFound();
            }
            return View(speakers);
        }

        [HttpPost]
        public ActionResult Edit(Speakers speakers)
        {
            if (ModelState.IsValid)
            {
                Speakers speakers1 = context.Speakers.Find(speakers.Id);

                if (speakers.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + speakers.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), speakers1.Image);
                    System.IO.File.Delete(oldPath);

                    speakers.ImgFile.SaveAs(imgPath);
                    speakers1.Image = imgName;
                }
                speakers1.Name = speakers.Name;
                speakers1.Profession = speakers.Profession;
                

                context.Entry(speakers1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(speakers);
        }

        public ActionResult Delete(int Id)
        {
            Speakers speakers = context.Speakers.Find(Id);
            if (speakers == null)
            {
                return HttpNotFound();
            }
            context.Speakers.Remove(speakers);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}