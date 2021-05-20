using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public int PhoneNumber { get; set; }
    }
}