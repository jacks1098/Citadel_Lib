using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.ViewModels
{
    public class ManageBookViewModel
    {
        public Book Book { get; set; }
        public IEnumerable<CategoryType> CategoryTypes { get; set; }
        public IEnumerable<Author> Authors { get; set; }
    }
}