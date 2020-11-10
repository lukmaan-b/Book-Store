using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.FileProviders;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        readonly private ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Book> books = _db.Books;
            return View(books);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _db.Books.Add(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var bookInDb = _db.Books.Find(id);
            if(bookInDb == null)
            {
                return NotFound();
            }

            return View(bookInDb);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }
            _db.Books.Update(book);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var bookInDb = _db.Books.Find(id);
            if (bookInDb == null)
            {
                return NotFound();
            }
            _db.Books.Remove(bookInDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
