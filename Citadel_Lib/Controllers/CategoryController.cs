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
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;
        public CategoryController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add(CategoryTypeDto categoryDto)
        {
            if (!ModelState.IsValid)
                return View("Index", categoryDto);

            var category = AutoMapper.Mapper.Map<CategoryTypeDto,CategoryType>(categoryDto);
            _context.CategoryTypes.Add(category);
            _context.SaveChanges();

            return RedirectToAction("Add", "Book");
        }
    }
}