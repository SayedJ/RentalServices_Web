using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RSMVC.Models
{
    public class ApplicationUser  
    {
        
        public string Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Name:")]
        public string? FirstName { get; set; }


        [StringLength(50)]
        [Display(Name = "Last Name:")]
        public string? LastName { get; set; }

        [Display(Name = "A username for easier future access.")]
        public string? UserName { get; set; }


        [Display(Name = "Email:")]
        [EmailAddress(ErrorMessage = "")]
        public string? Email { get; set; }

        [PasswordPropertyText]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Mobile Phone")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{2})\)?[-. ]?([0-9]{2})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public long? MobileNo { get; set; }

        public ICollection<string>? Roles { get; set; }
    }
}
