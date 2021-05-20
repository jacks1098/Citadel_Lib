using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Models
{
    public class CategoryType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}