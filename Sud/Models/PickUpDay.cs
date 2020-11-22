using System.ComponentModel.DataAnnotations;

namespace Sud.Models
{
    public class PickUpDay
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Pickup Day")]
        public string Date { get; set; }
    }
}