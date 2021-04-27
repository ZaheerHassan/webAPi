using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace webAPi.Dtos
{
    public class UserToRegisterDto
    {
        [Required]
     public string Username { get; set; }
        public string Gender { get; set; }
        public string KnownAs { get; set; }
     public DateTime DateOfBirth { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="You must specify Password")]
    public string Password { get; set; }
    }
} 
