using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<int> BookIds { get; set; }
        public Book Book { get; set; }

    }
}