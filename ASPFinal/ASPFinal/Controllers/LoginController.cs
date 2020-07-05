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
    public class LoginController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(vmLogin vmLogin)
        {
            if (ModelState.IsValid)
            {
                Users users = context.Users.FirstOrDefault(u => u.Username == vmLogin.Username);
                if (users!=null)
                {
                    if (users.Password == vmLogin.Password)
                    {
                        Session["Loginner"] = true;
                        Session["LoginnerId"] = users.Id;

                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "Incorrect Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("Username", "Incorrect Username");
                }
            }
            return View(vmLogin);
        }
    }
}