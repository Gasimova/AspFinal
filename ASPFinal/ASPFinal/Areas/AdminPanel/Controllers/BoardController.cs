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
    public class BoardController : Controller
    {
        EduHomeContext context = new EduHomeContext();
        // GET: AdminPanel/Board
        public ActionResult Index()
        {
            if (Session["Loginner"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            List<Board> boards = context.Boards.ToList();
            return View(boards);
        }

        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(Board board)
        {
            if (ModelState.IsValid)
            {
                context.Boards.Add(board);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(board);
        }

        public ActionResult Edit(int Id)
        {
            Board board = context.Boards.Find(Id);
            if (board == null)
            {
                return HttpNotFound();
            }
            return View(board);
        }

        [HttpPost]
        public ActionResult Edit(Board board)
        {
            if (ModelState.IsValid)
            {
                context.Entry(board).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(board);
        }

        public ActionResult Delete(int Id)
        {
            Board board = context.Boards.Find(Id);
            if (board == null)
            {
                return HttpNotFound();
            }

            context.Boards.Remove(board);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}