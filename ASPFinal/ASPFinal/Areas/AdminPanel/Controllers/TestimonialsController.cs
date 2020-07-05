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
    public class TestimonialsController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Testimonials
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Testimonials> testimonials = context.Testimonials.ToList();
            return View(testimonials);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Testimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                if (testimonials.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(testimonials);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + testimonials.ImgFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                testimonials.ImgFile.SaveAs(imgPath);
                testimonials.Image = imgName;

                context.Testimonials.Add(testimonials);
                context.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(testimonials);
        }

        public ActionResult Edit(int Id)
        {
            Testimonials testimonials = context.Testimonials.Find(Id);
            if (testimonials == null)
            {
                return HttpNotFound();
            }
            return View(testimonials);
        }

        [HttpPost]
        public ActionResult Edit(Testimonials testimonials)
        {
            if (ModelState.IsValid)
            {
                Testimonials testimonials1 = context.Testimonials.Find(testimonials.Id);

                if (testimonials.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + testimonials.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), testimonials1.Image);
                    System.IO.File.Delete(oldPath);

                    testimonials.ImgFile.SaveAs(imgPath);
                    testimonials1.Image = imgName;
                }
                testimonials1.Person = testimonials.Person;
                testimonials1.Position = testimonials.Position;
                testimonials1.Text = testimonials.Text;
               

                context.Entry(testimonials1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(testimonials);
        }

        public ActionResult Delete(int Id)
        {
            Testimonials testimonials = context.Testimonials.Find(Id);
            if (testimonials == null)
            {
                return HttpNotFound();
            }
            context.Testimonials.Remove(testimonials);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}