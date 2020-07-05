using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Areas.AdminPanel.Controllers
{
    public class ContactController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Contact
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Contact> contacts = context.Contacts.ToList();
            return View(contacts);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Contacts.Add(contact);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Edit(int Id)
        {
            Contact contact = context.Contacts.Find(Id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        [HttpPost]
        public ActionResult Edit(Contact contact)
        {
            if (ModelState.IsValid)
            {
                context.Entry(contact).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        public ActionResult Delete(int Id)
        {
            Contact contact = context.Contacts.Find(Id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}