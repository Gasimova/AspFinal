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
    public class TeachersController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Teachers
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Teachers> teachers = context.Teachers.ToList();
            return View(teachers);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                if (teachers.ImgFile == null)
                {
                    ModelState.AddModelError("", "Image is required");
                    return View(teachers);
                }

                string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teachers.ImgFile.FileName;
                string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                teachers.ImgFile.SaveAs(imgPath);
                teachers.Image = imgName;

                context.Teachers.Add(teachers);
                context.SaveChanges();

                return RedirectToAction("Index");

            }
            return View(teachers);
        }

        public ActionResult Edit(int Id)
        {
            Teachers teachers = context.Teachers.Find(Id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        [HttpPost]
        public ActionResult Edit(Teachers teachers)
        {
            if (ModelState.IsValid)
            {
                Teachers teachers1 = context.Teachers.Find(teachers.Id);

                if (teachers.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teachers.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), teachers1.Image);
                    System.IO.File.Delete(oldPath);

                    teachers.ImgFile.SaveAs(imgPath);
                    teachers1.Image = imgName;
                }
                teachers1.AboutMe = teachers.AboutMe;
                teachers1.Communication = teachers.Communication;
                teachers1.Degree = teachers.Degree;
                teachers1.Design = teachers.Design;
                teachers1.Development = teachers.Development;
                teachers1.Email = teachers.Email;
                teachers1.Experience = teachers.Experience;
                teachers1.Faculty = teachers.Faculty;
                teachers1.Hobbies = teachers.Hobbies;
                teachers1.Innovation = teachers.Innovation;
                teachers1.Language = teachers.Language;
                teachers1.Name = teachers.Name;
                teachers1.Phone = teachers.Phone;
                teachers1.Position = teachers.Position;
                teachers1.Skype = teachers.Skype;
                teachers1.TeamLeader = teachers.TeamLeader;
                

                context.Entry(teachers1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(teachers);
        }

        public ActionResult Delete(int Id)
        {
            Teachers teachers = context.Teachers.Find(Id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            context.Teachers.Remove(teachers);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}