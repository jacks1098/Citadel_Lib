using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Dto
{
    public class BookDto
    {
        public int Id { get; set; }
        public int IBSN { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto Author { get; set; }
        public int CategoryId { get; set; }
        public CategoryTypeDto CategoryType { get; set; }
    }
}