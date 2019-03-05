using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreOnlineBookStore.Controllers
{
    public class BookCategoryController : Controller
    {
        OnlineBookStoreDbContext context = new OnlineBookStoreDbContext();
        public ViewResult Index()
        {
            var caty = context.Categorys.ToList();
            return View(caty);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind("CategoryName, CategoryDescription")]BookCategory c1)
        {
            if (ModelState.IsValid)
            {
                context.Categorys.Add(c1);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(c1);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            BookCategory caty = context.Categorys.Find(id);

            return View(caty);
        }
        [HttpPost]
        public ActionResult Delete(int id, BookCategory c1)
        {
            var caty = context.Categorys.Where(x => x.CategoryId == id).SingleOrDefault();
            context.Categorys.Remove(caty);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BookCategory caty = context.Categorys.Where(x => x.CategoryId == id).SingleOrDefault();


            return View(caty);
        }
        [HttpPost]
        public ActionResult Edit(BookCategory c1)
        {
            BookCategory caty = context.Categorys.Where(x => x.CategoryId == c1.CategoryId).SingleOrDefault();
            context.Entry(caty).CurrentValues.SetValues(c1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            BookCategory caty = context.Categorys.Where(x => x.CategoryId == id).SingleOrDefault();
            context.SaveChanges();
            return View(caty);
        }
    }
}