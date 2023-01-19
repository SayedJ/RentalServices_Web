using System.ComponentModel.DataAnnotations;

namespace RSMVC.Models
{
    public class RentalSetUp
    {

        [Key]
        public int ResId { get; set; }
        public DateTime? BookingConfirmed { get; set; }

        public string? BookingStatus { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public RentalInfoSystem RentalSystem { get; set; }


    }
}
