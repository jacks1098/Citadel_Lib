using Citadel_Lib.Models;
using Citadel_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Citadel_Lib.Dto;

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
            var categoryTypes = _context.CategoryTypes.ToList();
            var authors = _context.Authors.ToList();

            var viewModel = new ManageBookViewModel
            {
                BookDto = Mapper.Map<Book,BookDto>(new Book()),
                CategoryTypeDtos = categoryTypes.Select(Mapper.Map<CategoryType, CategoryTypeDto>),
                AuthorDtos = authors.Select(Mapper.Map<Author, AuthorDto>)
            };

            return View(viewModel);
        }

        [Authorize(Roles = RollName.CanManageRentals)]
        public ActionResult Save(BookDto bookDto)
        {
            if(ModelState.IsValid)
            {
                var book = Mapper.Map<BookDto, Book>(bookDto);
                book.Id = bookDto.Id;

                if (book.Id == 0)
                {
                    book.PurchaseDate = DateTime.Now;
                    _context.Books.Add(book);
                }
                else
                {
                    var bookInDb = _context.Books.Single(x => x.Id == book.Id);
                    bookInDb.Title = book.Title;
                    bookInDb.IBSN = book.IBSN;
                    bookInDb.AuthorId = book.AuthorId;
                    bookInDb.CategoryTypeId = book.CategoryTypeId;
                    bookInDb.PublishedDate = book.PublishedDate;
                    bookInDb.Price = book.Price;
                    bookInDb.CopiesAvailable = book.CopiesAvailable;
                }
                
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

            var categoryTypes = _context.CategoryTypes.ToList();
            var authors = _context.Authors.ToList();

            var viewModel = new ManageBookViewModel
            {
                BookDto = Mapper.Map<Book,BookDto>(book),
                CategoryTypeDtos = categoryTypes.Select(Mapper.Map<CategoryType,CategoryTypeDto>),
                AuthorDtos = authors.Select(Mapper.Map<Author, AuthorDto>)
            };

            return View("Add", viewModel);
        }
    }
}