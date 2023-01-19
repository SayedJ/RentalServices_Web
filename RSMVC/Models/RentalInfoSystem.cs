using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace RSMVC.Models
{
    public class RentalInfoSystem
    {
        [Key]
        public int Id { get; set; }[Key]
        
        public string? Rules { get; set; }

        public string? PaymentRules { get; set; }
        public string? PaymentMethod { get; set; }

        public bool TermsAccepted { get; set; }

        public Shipping? Collecting { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public RentalSetUp RentingDateInfo { get; set; }
    }
}
