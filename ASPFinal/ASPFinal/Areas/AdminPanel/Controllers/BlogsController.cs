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
    public class BlogsController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Blogs
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Blogs> blogs = context.Blogs.Include("Users").ToList();
            return View(blogs);
        }


        //public ActionResult Create()
        //{
        //    ViewBag.Users = context.Users.ToList();
        //    return View();
        //}


        //[HttpPost]
        //[ValidateInput(false)]
        //public ActionResult Create(Blogs blogs)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        if (blogs.ImgFile == null)
        //        {
        //            ModelState.AddModelError("", "Image is required");
        //            return View(blogs);
        //        }

        //        string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blogs.ImgFile.FileName;
        //        string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

        //        blogs.ImgFile.SaveAs(imgPath);
        //        blogs.Image = imgName;

        //        context.Blogs.Add(blogs);
        //        context.SaveChanges();
        //        return RedirectToAction("Index");
              
        //    }
        //    ViewBag.Users = context.Users.ToList();
        //    return View(blogs);
        //}


        public ActionResult Edit(int Id)
        {
            Blogs blogs = context.Blogs.Find(Id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Users = context.Users.ToList();
            return View(blogs);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Blogs blogs)
        {
            if (ModelState.IsValid)
            {
                Blogs blogs1 = context.Blogs.Find(blogs.Id);

                if (blogs.ImgFile != null)
                {
                    string imgName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blogs.ImgFile.FileName;
                    string imgPath = Path.Combine(Server.MapPath("~/Uploads/"), imgName);

                    string oldPath = Path.Combine(Server.MapPath("~/Uploads"), blogs1.Image);
                    System.IO.File.Delete(oldPath);

                    blogs.ImgFile.SaveAs(imgPath);
                    blogs1.Image = imgName;
                }

                blogs1.CreatedDate = blogs.CreatedDate;
                blogs1.ReadCount = blogs.ReadCount;
                blogs1.Text = blogs.Text;
                blogs1.Title = blogs.Title;

                context.Entry(blogs1).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Users = context.Users.ToList();
            return View(blogs);
        }

        public ActionResult Delete(int Id)
        {
            Blogs blogs = context.Blogs.Find(Id);
            if (blogs == null)
            {
                return HttpNotFound();
            }
            context.Blogs.Remove(blogs);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}