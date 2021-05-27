using AutoMapper;
using Citadel_Lib.Dto;
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

        public IEnumerable<RentalDto> GetRentals()
        {
            var rentalDtos = _context.Rentals
                .Include(x => x.Book)
                .Include(x => x.Book.Author)
                .Include(x => x.Book.CategoryType)
                .Include(x => x.User)
                .ToList()
                .Where(x => x.ReturnedDate == null)
                .Select(Mapper.Map<Rental,RentalDto>)
               ;

            return rentalDtos;
        }

        public IEnumerable<RentalDto> GetRentals(int id)
        {
            
            if (id == -1)
                return _context.Rentals
                    .Include(x => x.Book)
                    .Include(x => x.User)
                    .ToList()
                    .Select(Mapper.Map<Rental, RentalDto>);
            
            return _context.Rentals
                .Include(x => x.Book)
                .Include(x => x.User)
                .ToList()
                .Where(x => x.ReturnedDate == null && x.UserId == id)
                .Select(Mapper.Map<Rental, RentalDto>);

        }

        [System.Web.Http.HttpPost]
        public IHttpActionResult CreateRental(RentalDto rentalDto)
        {
            var errorMessage = "";
            var user = _context.User.Single(x => x.Id == rentalDto.UserId);
            var books = _context.Books.Include(x => x.Author).Include(x => x.CategoryType).Where(x => rentalDto.BookIds.Contains(x.Id)).ToList();

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
                        errorMessage += "Rental for "+ book.Title +" already existed with same user.\n";
                    }
                }
                else
                {
                    errorMessage += "Currently "+ book.Title +" is not available.\n";
                }
            }
            _context.SaveChanges();
            
            if(errorMessage == "")
                return Ok();
            return BadRequest(errorMessage);
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
