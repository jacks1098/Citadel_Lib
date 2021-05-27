using Citadel_Lib.Dto;
using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Citadel_Lib.Controllers.API
{

    public class UserController : ApiController
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

        // GET api/user
        [Authorize]
        public IEnumerable<UserDto> GetUsers(string query = null)
        {
            var users = _context.User.ToList().Where(x => x.IsExistUser == true);

            if(!String.IsNullOrWhiteSpace(query))
            {
                users = users.ToList().Where(x => x.Name.Contains(query));
            }

            var userDtos = users.Select(AutoMapper.Mapper.Map<User,UserDto>);
            
            return userDtos;
        }

        // DELETE api/user/{id}
        [HttpDelete]
        [Authorize(Roles = RollName.CanManageRentals)]
        public void DeleteUser(int id)
        {
            var userInDb = _context.User.SingleOrDefault(x => x.Id == id && x.IsExistUser == true);

            if (userInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            userInDb.LeaveDate = DateTime.Now;
            userInDb.IsExistUser = false;
            _context.SaveChanges();
        }
    }
}
