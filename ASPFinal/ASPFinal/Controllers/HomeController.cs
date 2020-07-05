using ASPFinal.DAL;
using ASPFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class HomeController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        public ActionResult Index()
        {
            vmHome home = new vmHome();
            home.About = context.Abouts.FirstOrDefault();
            home.Blogs = context.Blogs.ToList();
            home.Boards = context.Boards.ToList();
            home.Courses = context.Courses.ToList();
            home.Events = context.Events.ToList();
            home.Testimonials = context.Testimonials.ToList();
            home.MainSliders = context.MainSliders.ToList();

            ViewBag.Page = "Home";

            return View(home);
        }

        
    }
}