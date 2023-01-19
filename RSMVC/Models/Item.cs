using System.ComponentModel.DataAnnotations;

namespace RSMVC.Models
{
    public class Item
    {

       
        public int Id { get; set; }

        [Required]
        [Display(Name = "Items Name")]
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
       
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


        public virtual Category Category { get; set; }

        [Required]
        public virtual Availability Availability { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Purchased Date:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public DateTime BoughtDate { get; set; }


        public virtual Condition ItemCondition { get; set; }

        public string Brand { get; set; }

    }

    public enum Availability
    {
        Available,
        Rented,
        Unavailable
    }

    public enum Condition
    {
        New,
        LikeNew,
        Good,
        Fair,
        Poor

    }
}
