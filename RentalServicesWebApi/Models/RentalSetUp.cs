using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentalServicesWebApi.Models
{
    public class RentalSetUp
    {

        [Key]
        public int ResId { get; set; }

        public DateTime? BookingConfirmed { get; set; }

        public string? BookingStatus { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [ForeignKey("BookingSystem")]
        public int Booking_id { get; set; }
        public BookingSystem? BookingSystem { get; set; }



    }
}
