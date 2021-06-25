using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
      
        public ActionResult Listbook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Books.ToList();
            return View(listBook);
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if(book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public ActionResult Create(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            context.Books.AddOrUpdate(book);
            context.SaveChanges();
            var a = "";
            return RedirectToAction("ListBook");
        }

        public ActionResult Edit(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            Book bookUpdate = context.Books.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                context.Books.AddOrUpdate(book);
                context.SaveChanges();
            }

            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize]
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Books.SingleOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
    }
}