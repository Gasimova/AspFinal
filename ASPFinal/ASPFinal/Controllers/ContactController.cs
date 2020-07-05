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
    public class ContactController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Contact
        public ActionResult Index()
        {
            vmContact contact = new vmContact();
            contact.Contacts = context.Contacts.ToList();

            ViewBag.Page = "Contact";

            return View(contact);
        }
    }
}