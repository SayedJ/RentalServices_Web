using Microsoft.AspNetCore.Http;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace RentalServicesWebApi.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        
        
        
        public string? Name { get; set; }

        public decimal? Price { get; set; }

        public int Category_id { get; set; }
        [ForeignKey("Category_id")]
        public virtual Category? Category { get; set; }

        
        public virtual Availability? Availability { get; set; }

        
        public string? Description { get; set; }

        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM-yyyy}")]
        public DateTime BoughtDate { get; set; }

     
        public virtual Condition? ItemCondition { get; set; }

        public string? Brand { get; set; }
        

        public virtual ICollection<BookingSystem>? BookingSystem { get; set; }


    }

   

    
   
}
