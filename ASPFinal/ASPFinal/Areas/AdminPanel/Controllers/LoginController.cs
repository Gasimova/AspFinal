using ASPFinal.DAL;
using ASPFinal.Models;
using ASPFinal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPFinal.Areas.AdminPanel.Controllers
{
    public class LoginController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(vmAdmin vmAdmin)
        {
            if (ModelState.IsValid)
            {
                Admins admins = context.Admins.FirstOrDefault(u => u.Email == vmAdmin.Email);
                if (admins != null)
                {
                    if (admins.Password == vmAdmin.Password)
                    {
                        Session["Loginner"] = true;
                        Session["LoginnerId"] = admins.Id;

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Incorrect Email");
                }
            }
            return View(vmAdmin);
        }
    }
}