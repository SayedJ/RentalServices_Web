using System.ComponentModel.DataAnnotations;

namespace RentalServicesWebApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [Display(Name = "Items Name")]
        public string? Name { get; set; }

        public decimal? Price { get; set; }
       
        [Required]
        public string ImagePath { get; set; }
        
        [Required]
        [Display(Name = "Choose a Category")]
        public virtual List<Category>? Category { get; set; }
    }
}
