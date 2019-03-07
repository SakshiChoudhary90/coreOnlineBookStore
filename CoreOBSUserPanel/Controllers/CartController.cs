using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreOBSUserPanel.Helpers;
using CoreOBSUserPanel.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreOBSUserPanel.Controllers
{
    [Route("cart")]
    public class CartController : Controller
    {
        OnlineBookStoreDbContext context = new OnlineBookStoreDbContext();
        [Route("index")]
        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");

            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.BookDetails.BookPrice * item.Quantity);

            return View();
        }

        [Route("buy/{id}")]
        public IActionResult Buy(int id)
        {
            if (SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart") == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { BookDetails = context.Books.Find(id), Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            else
            {
                List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
                int index = isExist(id);
                if(index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new Item { BookDetails = context.Books.Find(id), Quantity = 1 });
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }
            return RedirectToAction("Index");
        }

        [Route("remove/{id}")]
        public IActionResult Remove(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            int index = isExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }
        private int isExist(int id)
        {
            List<Item> cart = SessionHelper.GetObjectFromJson<List<Item>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].BookDetails.BookId.Equals(id))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}