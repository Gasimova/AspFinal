using ASPFinal.DAL;
using ASPFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class EventRightController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: EventRight
        public ActionResult Index()
        {
            vmEventRight right = new vmEventRight();
            right.Categories = context.Categories.ToList();
            right.Tags = context.Tags.ToList();
            right.Events = context.Events.ToList();

            ViewBag.Page = "EventRight";
            return View(right);
        }


        public ActionResult Details(int Id)
        {
            vmEventRight right = new vmEventRight();
            right.Categories = context.Categories.ToList();
            right.Tags = context.Tags.ToList();
            right.Events = context.Events.ToList();
            right.Speakers = context.Speakers.ToList();
            right.Event = context.Events.FirstOrDefault();
            right.Event = context.Events.Find(Id);


            return View(right);
        }
        
    }
}