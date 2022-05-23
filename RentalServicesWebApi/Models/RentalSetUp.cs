using System.ComponentModel.DataAnnotations;

namespace RentalServicesWebApi.Models
{
    public class RentalSetUp
    {

        [Key]
        public int ResId { get; set; }
        public DateTime? BookingConfirmed { get;}

        public string? BookingStatus { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }


    }
}
