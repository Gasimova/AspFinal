using ASPFinal.DAL;
using ASPFinal.Models;
using ASPFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class BlogController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Blog
        public ActionResult Index()
        {
            List<Blogs> blogs = context.Blogs.ToList();
            ViewBag.Page = "Blog";
            ViewBag.PAGE = "Blog";

            return View(blogs);
        }

        public ActionResult Details(int Id)
        {
            vmBlofLeft blofLeft = new vmBlofLeft();
            blofLeft.Blogs = context.Blogs.ToList();
            blofLeft.Blog = context.Blogs.Find(Id);
            blofLeft.Events = context.Events.ToList();
            blofLeft.Categories = context.Categories.ToList();
            blofLeft.Tags = context.Tags.ToList();
            blofLeft.Messages = context.Messages.ToList();
            blofLeft.Event = context.Events.FirstOrDefault();

            return View(blofLeft);
        }
    }
}