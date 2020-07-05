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
    public class AboutController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: About
        public ActionResult Index()
        {
            vmAbout vmAbout = new vmAbout();
            vmAbout.About = context.Abouts.FirstOrDefault();
            vmAbout.Teachers = context.Teachers.ToList();
            vmAbout.Boards = context.Boards.ToList();
            vmAbout.Testimonials = context.Testimonials.ToList();

            ViewBag.Page = "About";

            return View(vmAbout);
        }
    }
}