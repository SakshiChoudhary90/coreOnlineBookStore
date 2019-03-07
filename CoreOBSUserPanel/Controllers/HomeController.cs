using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreOBSUserPanel.Models;

namespace CoreOBSUserPanel.Controllers
{
    public class HomeController : Controller
    {
        OnlineBookStoreDbContext context = new OnlineBookStoreDbContext();
        public IActionResult Index()
        {
            var book = context.Books.ToList();
            return View(book);
        }

      
    }
}
