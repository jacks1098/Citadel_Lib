using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Citadel_Lib.Controllers.API
{
    [Authorize(Roles = RollName.CanManageRentals)]
    public class BookController : ApiController
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

        // GET api/book
        public IHttpActionResult GetBooks(string query = null)
        {
            var books = _context.Books.Include(x => x.CategoryType).Include(x => x.Author).Where(x => x.IsAvailable == true).ToList();

            if (!String.IsNullOrWhiteSpace(query))
                books = books.Where(x => x.Title.Contains(query) && x.IsAvailable == true && x.CopiesAvailable > 0).ToList();

            return Ok(books);
        }

        // GET api/book/{id}
        [HttpDelete]
        public void DeleteBook(int id)
        {
            var bookInDb = _context.Books.SingleOrDefault(x => x.Id == id && x.IsAvailable == true);

            var bookInRental = _context.Rentals.SingleOrDefault(x => x.Book.Id == id);

            if(bookInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            if (bookInRental != null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            bookInDb.IsAvailable = false;
            _context.SaveChanges();
        }
    }
}
