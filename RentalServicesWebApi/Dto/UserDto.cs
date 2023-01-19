using System;
using System.ComponentModel.DataAnnotations;

namespace RentalServicesWebApi.Dto
{


    public class LoginUserDto
    {
       
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        public string? UserName { get; set; }

        public string Password { get; set; }
    }


    public class UserDto : LoginUserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long MobileNo { get; set; }
        public ICollection<string> Roles { get; set; }






    }
}

