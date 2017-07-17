using Books.Models.Data;
using Books.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.Controllers
{
    public class HomeController : Controller
    {
        private DataSource db = new DataSource();
        // GET: Home
        public ActionResult Index()
        {
            IEnumerable<Book> books = db.Books.ToList();

            return View(books);
        }

        [HttpGet]
        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateBook(int id)
        {
            Book book = db.Books.FirstOrDefault(p => p.Id == id);

            return View(book);
        }

        [HttpPost]
        public ActionResult UpdateBook(Book book)
        {
            Book bookToUpdate = db.Books.FirstOrDefault(p => p.Id == book.Id);

            db.Entry(bookToUpdate).CurrentValues.SetValues(book);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DeleteBook(int id)
        {
            Book bookToDelete = db.Books.FirstOrDefault(p => p.Id == id);

            db.Books.Remove(bookToDelete);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}