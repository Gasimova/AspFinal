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
    public class EventController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Event
        public ActionResult Index()
        {
            List<Events> events = context.Events.ToList();

            ViewBag.Page = "Event";
            ViewBag.PAGE = "Event";

            return View(events);
        }

        public ActionResult Details(int Id)
        {
            vmEventRight right = new vmEventRight();
            right.Categories = context.Categories.ToList();
            right.Tags = context.Tags.ToList();
            right.Events = context.Events.ToList();
            right.Messages = context.Messages.ToList();
            right.Speakers = context.Speakers.ToList();
            right.Event = context.Events.FirstOrDefault();
            right.Event = context.Events.Find(Id);


            return View(right);
        }
    }
}