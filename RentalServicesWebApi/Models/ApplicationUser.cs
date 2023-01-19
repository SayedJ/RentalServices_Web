using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RentalServicesWebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        
        [StringLength(50)]
        public string? FirstName { get; set; }

       
        [StringLength(50)]
        public string? LastName { get; set; }

        
        public override string? UserName { get; set; }

        
        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "")]
        public override string? Email { get; set; }
            
        [PasswordPropertyText]
        public string? Password { get; set; }
        
        
        public long MobileNo { get; set; }

        public ICollection<Address>? Addresses { get; set; }

        
        public ICollection<BookingSystem>? BookingSystems { get; set; }



    }
}

