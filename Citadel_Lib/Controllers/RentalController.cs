using Citadel_Lib.Models;
using Citadel_Lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citadel_Lib.Controllers
{
    [Authorize(Roles = RollName.CanManageRentals)]
    public class RentalController : Controller
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
        // GET: Rental
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult History()
        {
            return View();
        }
    }
}