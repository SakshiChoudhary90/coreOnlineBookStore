using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace coreOnlineBookStore.Controllers
{
    public class BookController : Controller
    {
        OnlineBookStoreDbContext context = new OnlineBookStoreDbContext();
        public ViewResult Index()
        {
            var books = context.Books.ToList();
            return View(books);
        }
        [HttpGet]
        public ViewResult Create()
        {
            ViewBag.publications = new SelectList(context.Publications, "PublicationId", "PublicationName");
            ViewBag.categorys = new SelectList(context.Categorys, "CategoryId", "CategoryName");
            ViewBag.authors = new SelectList(context.Authors, "AuthorId", "AuthorName");
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("BookName,BookType,BookImage,BookPrice")]Book b1)
        {
            if (ModelState.IsValid)
            {
                context.Books.Add(b1);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(b1);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Book bk = context.Books.Find(id);

            return View(bk);
        }
        [HttpPost]
        public ActionResult Delete(int id, Book b1)
        {
            var bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();
            context.Books.Remove(bk);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Book bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();


            return View(bk);
        }
        [HttpPost]
        public ActionResult Edit(Book b1)
        {
            Book bk = context.Books.Where
                (x => x.BookId == b1.BookId).SingleOrDefault();
            context.Entry(bk).CurrentValues.SetValues(b1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Book bk = context.Books.Where(x => x.BookId == id).SingleOrDefault();
            context.SaveChanges();
            return View(bk);
        }
    }
}
