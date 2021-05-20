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
    [System.Web.Http.Authorize(Roles = RollName.CanManageRentals)]
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;
        public RentalController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IHttpActionResult GetRentals()
        {
            var rentals = _context.Rentals.Include(x => x.Book).Include(x => x.User).Where(x => x.ReturnedDate == null).ToList();
            return Ok(rentals);
        }

        public IHttpActionResult GetRentals(int id)
        {
            dynamic rental;
            
            if (id == -1)
                rental = _context.Rentals.Include(x => x.Book).Include(x => x.User).ToList();
            else
                rental = _context.Rentals.Include(x => x.Book).Include(x => x.User).Where(x => x.ReturnedDate == null && x.UserId == id).ToList();
           
            return Ok(rental);
        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateRental(Rental rental)
        {
            var user = _context.User.Single(x => x.Id == rental.UserId);
            var books = _context.Books.Include(x => x.Author).Include(x => x.CategoryType).Where(x => rental.BookIds.Contains(x.Id)).ToList();

            foreach(var book in books)
            {
                if(book.IsAvailable && book.CopiesAvailable > 0)
                {
                    var rentalInDb = _context.Rentals.Include(x => x.Book).Include(x => x.User).SingleOrDefault(x => x.UserId == user.Id && x.Book.Id == book.Id && x.ReturnedDate == null);
                    if(rentalInDb == null)
                    {
                        --book.CopiesAvailable;
                        ++book.NumberOfTimeIssued;
                        var newRental = new Rental
                        {
                            Book = book,
                            User = user,
                            RentedDate = DateTime.Now
                        };

                        _context.Rentals.Add(newRental);
                    }
                    else
                    {
                        ModelState.AddModelError("Error", "Rental already existed with same user.");   
                        return BadRequest("Rental already existed with same user.");
                    }
                }
                else
                {
                    return BadRequest("Currently Book is not available.");
                }
            }
            _context.SaveChanges();
            return Ok();
        }

        [System.Web.Http.HttpDelete]
        public void DeleteRental(int id)
        {
            var rentalInDb = _context.Rentals.Include(x => x.Book).Include(x => x.User).SingleOrDefault(x => x.Id == id && x.ReturnedDate == null);
            if(rentalInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.ExpectationFailed);
            }
            else
            {
                rentalInDb.ReturnedDate = DateTime.Now;
                ++rentalInDb.Book.CopiesAvailable;
                _context.SaveChanges();
            }
        }
    }
}
