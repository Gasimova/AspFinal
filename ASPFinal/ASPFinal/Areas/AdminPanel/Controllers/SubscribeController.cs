using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Areas.AdminPanel.Controllers
{
    public class SubscribeController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Subscribe
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Subscribe> subscribes = context.Subscribes.ToList();
            return View(subscribes);
        }
    }
}