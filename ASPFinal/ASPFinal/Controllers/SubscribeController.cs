using ASPFinal.DAL;
using ASPFinal.Models;
using ASPFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class SubscribeController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Subscribe
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Subscribe(vmSubscribe subscribe)
        {
            if (!string.IsNullOrEmpty(subscribe.EMAIL))
            {

                Subscribe subscribe1 = new Subscribe();
                subscribe1.Email = subscribe.EMAIL;
                subscribe1.CreatedDate = DateTime.Now;

                context.Subscribes.Add(subscribe1);
                context.SaveChanges();


                Session["Successful"] = true;
            }
            else
            {
                Session["nullEmail"] = true;

            }


            if (subscribe.Page == "Home")
            {
                return RedirectToAction("Index", "Home");
            }

            if (subscribe.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }

            if (subscribe.Page == "Courses")
            {
                return RedirectToAction("Index", "Courses");
            }

            if (subscribe.Page == "CoursesDetails")
            {
                return RedirectToAction("Index", "CoursesDetails");
            }

            if (subscribe.Page == "Event")
            {
                return RedirectToAction("Index", "Event");
            }

            if (subscribe.Page == "EventRight")
            {
                return RedirectToAction("Index", "EventRight");
            }

            if (subscribe.Page == "EventDetails")
            {
                return RedirectToAction("Index", "EventDetails");
            }

            if (subscribe.Page == "Teacher")
            {
                return RedirectToAction("Index", "Teacher");
            }

            if (subscribe.Page == "TeacherDetails")
            {
                return RedirectToAction("Index", "TeacherDetails");
            }

            if (subscribe.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }

            if (subscribe.Page == "BlogDetails")
            {
                return RedirectToAction("Index", "BlogDetails");
            }

            if (subscribe.Page == "BlogLeft")
            {
                return RedirectToAction("Index", "BlogLeft");
            }

            if (subscribe.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
