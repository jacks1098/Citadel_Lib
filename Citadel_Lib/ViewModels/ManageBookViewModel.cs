using Citadel_Lib.Dto;
using Citadel_Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.ViewModels
{
    public class ManageBookViewModel
    {
        public BookDto BookDto { get; set; }
        public IEnumerable<CategoryTypeDto> CategoryTypeDtos { get; set; }
        public IEnumerable<AuthorDto> AuthorDtos { get; set; }
    }
}