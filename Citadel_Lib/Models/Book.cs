using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string IBSN { get; set; }
        public string Title { get; set; }
        public float? Price { get; set; }
        public DateTime? PublishedDate { get; set; }
        public DateTime? PurchaseDate { get; set; }

        [Display(Name ="Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }

        [Display(Name ="Category Type")]
        public int CategoryTypeId { get; set; } 
        public CategoryType CategoryType { get; set; }
        public int NumberOfTimeIssued { get; set; } = 0;

        [Display(Name ="Numbers of Copies")]
        public int? CopiesAvailable { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}