using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RentalServicesWebApi.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string? LastName { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Enter Email Address")]
        public string? Email { get; set; }
        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }
        [Required]
        [Phone]
        public long MobileNo { get; set; }
    }
}
