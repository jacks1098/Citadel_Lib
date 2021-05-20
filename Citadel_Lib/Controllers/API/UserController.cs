using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Citadel_Lib.Controllers.API
{
    [Authorize(Roles = RollName.CanManageRentals)]
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
        public IHttpActionResult GetUsers(string query = null)
        {
            var users = _context.User.Where(x => x.IsExistUser == true).ToList();

            if(!String.IsNullOrWhiteSpace(query))
            {
                users = users.Where(x => x.Name.Contains(query) && x.IsExistUser == true).ToList();
            }
            
            return Ok(users);
        }

        // DELETE api/user/{id}
        [HttpDelete]
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
