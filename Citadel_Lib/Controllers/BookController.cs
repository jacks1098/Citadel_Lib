using Citadel_Lib.Models;
using Citadel_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citadel_Lib.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext _context;
        public BookController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Book
        public ActionResult Index()
        {
            if (User.IsInRole("CanManageRentals"))
                return View("Index");
            else
                return View("ReadonlyIndex");
        }

        [Authorize(Roles = RollName.CanManageRentals)]
        public ActionResult Add()
        {
            var viewModel = new ManageBookViewModel
            {
                Book = new Book(),
            CategoryTypes = _context.CategoryTypes.ToList(),
            Authors = _context.Authors.ToList()
            };

            return View(viewModel);
        }

        [Authorize(Roles = RollName.CanManageRentals)]
        public ActionResult Save(Book book)
        {
            if(ModelState.IsValid)
            {
                
                book.PurchaseDate = DateTime.Now;
                _context.Books.Add(book);
                _context.SaveChanges();
            }
            
            return RedirectToAction("Index", "Book");
        }

        [Authorize(Roles = RollName.CanManageRentals)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.Id == id);
            if (book == null)
                return HttpNotFound();
            var viewModel = new ManageBookViewModel
            {
                Book = book,
                CategoryTypes = _context.CategoryTypes.ToList(),
                Authors = _context.Authors.ToList()
            };
            return View("Add", viewModel);
        }
    }
}