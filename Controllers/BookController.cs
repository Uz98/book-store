using Bookly.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bookly.Controllers
{
    public class BookController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Book
        public ActionResult Index()
        {
            var f = new List<Book>();
            foreach (var book in db.books)
            {
                if (book.Description.Length > 50) { 
                book.Description = book.Description.Substring(1,40)+"...";
                }
                f.Add(book);
            }
            return View(f);
        }

        //need to be improved
        public ActionResult all()
        {
            var f = new List<Book>();
            foreach (var book in db.books)
            {
                if (book.Description.Length > 50)
                {
                    book.Description = book.Description.Substring(1, 40) + "...";
                }
                f.Add(book);
            }
            return View(f);
        }



        public ActionResult Detail(int id)
        {
            
            return View(db.books.Find(id));
        }






        [Authorize]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            //Cover storing process
            string FileName = Path.GetFileNameWithoutExtension(book.CoverFile.FileName);
            string extension = Path.GetExtension(book.CoverFile.FileName);
            FileName = FileName + DateTime.Now.ToString("yymmssfff") + extension;
            book.CoverPath = "~/image/" + FileName;
            FileName = Path.Combine(Server.MapPath("~/image/"), FileName);
            book.CoverFile.SaveAs(FileName);

            db.books.Add(book);
            db.SaveChanges();

            return View();
        }







        [Authorize]
        public ActionResult DashBoard()
        {

            return View(db.books.ToList());
        }



        [Authorize]
        public ActionResult Delete(int id)
        {
            db.books.Remove(db.books.Find(id));
            db.SaveChanges();
            return RedirectToAction("DashBoard","Book");
        }


        [HttpPost]
        public ActionResult Search(string SearchWord)
        {
            var books = db.books.ToList();

            if (!String.IsNullOrEmpty(SearchWord))
            {
                books = db.books.Where(b => b.Title.Contains(SearchWord)).ToList();
            }
            
            
            return View(books);
        }




        public ActionResult Edit(int id)
        {

            return View(db.books.Find(id));
        }

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            var aa= db.books.Find(book.Id);
            aa.Price = book.Price;
            aa.Pages = book.Pages;
            aa.store = book.store;
            aa.Description = book.Description;
            aa.Title = book.Title;
            aa.CoverPath = book.CoverPath;
            aa.CoverFile = book.CoverFile;

            db.SaveChanges();
            return RedirectToAction("Index");
        }




    }
}