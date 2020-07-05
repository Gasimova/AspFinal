using ASPFinal.DAL;
using ASPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace ASPFinal.Controllers
{
    public class SignUpController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: SignUp
        public ActionResult Index()
        {
            //List<Users> users = context.Users.ToList();
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(Users users)
        {
            if (ModelState.IsValid)
            {
                if (context.Users.Any(u=>u.Email==users.Email))
                {
                    ModelState.AddModelError("Email", "This Email is already taken");
                }

                if (context.Users.Any(u => u.Username == users.Username))
                {
                    ModelState.AddModelError("Username", "This Usrname is already taken");
                }

                //Users users1 = new Users();
                //users1.Name = users.Name;
                //users1.Username = users.Username;
                //users1.Password = Crypto.HashPassword(users.Password);
                //users1.Phone = users.Phone;
                //users1.Email = users.Email;

                context.Users.Add(users);
                context.SaveChanges();

                return RedirectToAction("Login", "Login");
            }
            return View(users);
        }
    }
}