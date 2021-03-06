﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreOnlineBookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreOnlineBookStore.Controllers
{
    public class PublicationController : Controller
    {
        OnlineBookStoreDbContext context = new OnlineBookStoreDbContext();
        public ViewResult Index()
        {
            var publications = context.Publications.ToList();
            return View(publications);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("PublicationName, PublicationDescription")]Publication p1)
        {
           if(ModelState.IsValid)
            {
                context.Publications.Add(p1);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(p1);
        }

        public ActionResult Details(int id)
        {
            Publication Pub = context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();
            context.SaveChanges();
            return View(Pub);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Publication Pub = context.Publications.Find(id);

            return View(Pub);
        }
        [HttpPost]
        public ActionResult Delete(int id, Author p1)
        {
            var Pub = context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();
            context.Publications.Remove(Pub);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Publication Pub = context.Publications.Where(x => x.PublicationId == id).SingleOrDefault();


            return View(Pub);
        }
        [HttpPost]
        public ActionResult Edit(Publication p1)
        {
            Publication Pub = context.Publications.Where
                (x => x.PublicationId == p1.PublicationId).SingleOrDefault();
            context.Entry(Pub).CurrentValues.SetValues(p1);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}