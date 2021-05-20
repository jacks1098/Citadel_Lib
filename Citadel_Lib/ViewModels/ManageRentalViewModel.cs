using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.ViewModels
{
    public class ManageRentalViewModel
    {
        public Rental Rental { get; set; }
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}