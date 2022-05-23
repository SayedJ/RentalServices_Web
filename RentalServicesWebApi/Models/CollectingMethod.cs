using System.ComponentModel.DataAnnotations;

namespace RentalServicesWebApi.Models
{
    public class CollectingMethod
    {
        [Key]
        public int Id { get; set; }
        public DateTime Time { get; set; }
        public Collecting MeansOfCollection { get; set; }

        public DateTime MeetingTime { get; set; }
    }

    public enum Collecting
    {

        Delivery,
        PickUp,
        Post

    }
}
