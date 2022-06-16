using Bookly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookly.Controllers
{
    public class CartController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }


        public ActionResult AddToCart(int id)
        {
            var book = db.books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                GetCart().AddBook(book, 1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult DeleteFromCart(int id)
        {
            var book = db.books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                GetCart().DeleteBook(id);
            }
            return RedirectToAction("Index");
        }



        //for demo purpos, in the future i will use data from the database!
        public Cart GetCart()
        {
            var cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["cart"] = cart;
            }

            return cart;
        }



        public PartialViewResult Summary()
        {

            return PartialView(GetCart());
        }

        public ActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetails entity)
        {
            return View();
        }

    }
}