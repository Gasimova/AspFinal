using ASPFinal.DAL;
using ASPFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class BlogLeftController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: BlogLeft
        public ActionResult Index()
        {
            vmBlofLeft blofLeft = new vmBlofLeft();
            blofLeft.Blogs = context.Blogs.ToList();
            blofLeft.Events = context.Events.ToList();
            blofLeft.Categories = context.Categories.ToList();
            blofLeft.Tags = context.Tags.ToList();
            blofLeft.Event = context.Events.FirstOrDefault();

            ViewBag.Page = "BlogLeft";

            return View(blofLeft);
        }

        public ActionResult Details(int Id)
        {
            vmBlofLeft blofLeft = new vmBlofLeft();
            blofLeft.Blogs = context.Blogs.ToList();
            blofLeft.Blog = context.Blogs.Find(Id);
            blofLeft.Events = context.Events.ToList();
            blofLeft.Categories = context.Categories.ToList();
            blofLeft.Tags = context.Tags.ToList();
            blofLeft.Event = context.Events.FirstOrDefault();
            ViewBag.Page = "BlogLeft";

            return View(blofLeft);
        }

    }
}