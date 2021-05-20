using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Citadel_Lib.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Date of Birth")]
        public DateTime? BirthDate { get; set; }

        [Required]
        [MaxLength(10)]
        [MinLength(10)]
        public string PhoneNumber { get; set; }

        public bool IsExistUser { get; set; }

        public DateTime? JoinedDate { get; set; }

        public DateTime? LeaveDate { get; set; }
    }
}