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
    public class CoursesController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Courses
        public ActionResult Index()
        {
            List<Courses> courses = context.Courses.ToList();

            ViewBag.Page = "Courses";
            ViewBag.PAGE = "Courses";

            return View(courses);
        }

        

        public ActionResult Details(int Id)
        {
            vmCourseDetail detail = new vmCourseDetail();
            detail.Features = context.Features.FirstOrDefault();
            detail.Categories = context.Categories.ToList();
            detail.Events = context.Events.ToList();
            detail.Tags = context.Tags.ToList();
            detail.Messages = context.Messages.ToList();
            detail.Courses = context.Courses.Find(Id);

            return View(detail);
        }

       
    }
}