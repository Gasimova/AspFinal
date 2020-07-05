using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace ASPFinal.Areas.AdminPanel.Controllers
{
    public class MessagesController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Messages
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Messages> messages = context.Messages.ToList();
            return View(messages);
        }
    }
}