using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Dto
{
    public class RentalDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public int BookId { get; set; }
        public BookDto BookDto { get; set; }
    }
}