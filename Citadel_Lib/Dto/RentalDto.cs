using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Dto
{
    public class RentalDto
    {
        public int Id { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int UserId { get; set; }
        public UserDto UserDto { get; set; }
        public List<int> BookIds { get; set; }
        public BookDto BookDto { get; set; }
    }
}