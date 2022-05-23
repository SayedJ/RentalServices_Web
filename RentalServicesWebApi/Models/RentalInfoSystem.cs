using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace RentalServicesWebApi.Models
{
    public class RentalInfoSystem
    {
        [Key]
        public int Id { get; set; }[Key]
        public User? UserName { get; set; }
        public string? Rules { get; set; }

        public string? PaymentRules { get; }
        public string? PaymentMethod { get; set; }

        public bool TermsAccepted { get; set; }

        public CollectingMethod? Collecting { get; set; }

        public List<Item>? Items { get; set; }

        public RentalSetUp? RentingDateInfo { get; set; }
    }
}
