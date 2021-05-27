using AutoMapper;
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
    [Authorize]
    public class AuthorController : ApiController
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
        public IEnumerable<AuthorDto> GetAuthors(string query = null)
        {
            var authors = _context.Authors.ToList();
            

            if (!String.IsNullOrWhiteSpace(query))
                authors =  authors.Where(x => x.Name.Contains(query)).ToList();

            var authorDtos =authors.Select(Mapper.Map<Author, AuthorDto>);

            return authorDtos;
        }
    }
}
