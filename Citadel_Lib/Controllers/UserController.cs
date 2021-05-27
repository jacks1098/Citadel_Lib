using AutoMapper;
using Citadel_Lib.Dto;
using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Citadel_Lib.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        public UserController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: User
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
            var user = new User();
            var userDto = Mapper.Map<UserDto>(user);

            return View(userDto);
        }

        [Authorize(Roles = RollName.CanManageRentals)]
        public ActionResult Edit(int id)
        {
            var user = _context.User.Single(x => x.Id == id);
            var userDto = Mapper.Map<UserDto>(user);

            return View("Add",userDto);

        }

        [Authorize(Roles = RollName.CanManageRentals)]
        public ActionResult Save(UserDto userDto)
        {
            if(!ModelState.IsValid)
            {
                return View("Add", userDto);
            }

            var user = Mapper.Map<UserDto,User>(userDto);
            user.Id = userDto.Id;
            if(user.Id == 0)
            {
                user.IsExistUser = true;
                user.JoinedDate = DateTime.Now;
                _context.User.Add(user);
            }
            else
            {
                var userInDb = _context.User.Single(x => x.Id == user.Id);
                userInDb.Name = user.Name;
                userInDb.PhoneNumber = user.PhoneNumber;
                userInDb.BirthDate = user.BirthDate;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "User");
        }
    }
}