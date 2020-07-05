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
    public class MessagesController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Messages
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult SendMessage(vmMessage messages)
        {
            if (!string.IsNullOrEmpty(messages.message)/*|| !string.IsNullOrEmpty(messages.email) ||!string.IsNullOrEmpty(messages.subject) || !string.IsNullOrEmpty(messages.name)*/)
            {
                Messages mes = new Messages();
                mes.Name = messages.name;
                mes.Email = messages.email;
                mes.Subject = messages.subject;
                mes.Message = messages.message;

                context.Messages.Add(mes);
                context.SaveChanges();

                Session["Send"] = true;
            }
            else
            {
                Session["UnSend"] = true;
            }



            if (messages.PAGE == "Details")
            {
                return RedirectToAction("Details", "Courses");
            }

            if (messages.PAGE == "Details")
            {
                return RedirectToAction("Index", "Event");
            }

            if (messages.PAGE == "Details")
            {
                return RedirectToAction("Index", "Blog");
            }


            return RedirectToAction("Index", "Blog");
        }
    }
}