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
    public class EventsController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Events
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Events> events = context.Events.ToList();
            return View(events);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Events events)
        {
            if (ModelState.IsValid)
            {
                if (events.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(events);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + events.ImgFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                events.ImgFile.SaveAs(imgPath);
                events.Image = imgName;

                context.Events.Add(events);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(events);
        }

        public ActionResult Edit(int Id)
        {
            Events events = context.Events.Find(Id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }

        [HttpPost]
        public ActionResult Edit(Events events)
        {
            if (ModelState.IsValid)
            {
                Events events1 = context.Events.Find(events.Id);

                if (events.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + events.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), events1.Image);
                    System.IO.File.Delete(oldPath);

                    events.ImgFile.SaveAs(imgPath);
                    events1.Image = imgName;
                }
                events1.Text = events.Text;
                events1.Time = events.Time;
                events1.Title = events.Title;
                events1.Venue = events.Venue;
              

                context.Entry(events1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(events);
        }

        public ActionResult Delete(int Id)
        {
            Events events = context.Events.Find(Id);
            if (events == null)
            {
                return HttpNotFound();
            }
            context.Events.Remove(events);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}