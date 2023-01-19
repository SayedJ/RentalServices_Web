using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace RentalServicesWebApi.Models
{
    public class BookingSystem {

        [Key]
        public int Id { get; set; }

        public string? Rules { get; set; }

        public string? PaymentRules { get; set; }


        public bool TermsAccepted { get; set; }

        public virtual Shipping? Collecting { get; set; }

        public int Item_Id { get; set; }
        [ForeignKey("Item_Id")]
        public Item? Item { get; set; }

        public virtual Payment? Payment_Methods { get; set; }

        
        public virtual Address? Address { get; set; }

        public virtual RentalSetUp? RentingDateInfo { get; set; }

        //public Guid? User_id { get; set; }
        //[ForeignKey("User_id")]
        //public virtual ApplicationUser? Renter { get; set; }
    }
}
