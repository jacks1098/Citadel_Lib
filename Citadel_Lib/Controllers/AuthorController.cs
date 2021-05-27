using Citadel_Lib.Dto;
using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citadel_Lib.Controllers
{
    [Authorize(Roles = RollName.CanManageRentals)]
    public class AuthorController : Controller
    {
        private ApplicationDbContext _context;
        public AuthorController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add(AuthorDto authorDto)
        {
            if (!ModelState.IsValid)
                return View("Index", authorDto);

            var author = AutoMapper.Mapper.Map<Author>(authorDto);
            _context.Authors.Add(author);
            _context.SaveChanges();

            return RedirectToAction("Index", "Category");
        }
    }
}