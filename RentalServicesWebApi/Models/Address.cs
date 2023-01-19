using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalServicesWebApi.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? House_no { get; set; }
        public string? Street_no { get; set; }
        public string? City_name { get; set; }
        public int Postal_code { get; set; }

        public int Booking_id { get; set; }
        [ForeignKey("Booking_id")]
        public virtual BookingSystem? Booking { get; set; }

        public Guid User_id { get; set; }
        [ForeignKey("User_id")]
        public virtual ICollection<ApplicationUser>? Users { get; set; }
    }
}