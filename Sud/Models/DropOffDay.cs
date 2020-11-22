using System.ComponentModel.DataAnnotations;

namespace Sud.Models
{
    public class DropOffDay
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Drop off Day")]
        public string Date { get; set; }
    }
}