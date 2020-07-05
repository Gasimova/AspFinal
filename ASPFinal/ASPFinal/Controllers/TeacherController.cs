using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class TeacherController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Teacher
        public ActionResult Index()
        {
            List<Teachers> teachers = context.Teachers.ToList();

            ViewBag.Page = "Teacher";
            return View(teachers);
        }

        public ActionResult Details(int Id)
        {
            Teachers teachers = context.Teachers.Find(Id);
            return View(teachers);
        }
    }
}