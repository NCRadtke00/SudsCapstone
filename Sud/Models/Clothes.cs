using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Models
{
    public class Clothes
    {
        public Clothes()
        {

            Reviews = new HashSet<Reviews>();
        }
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Name should only include letters and number.")]
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [Range(0, 1000)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public bool IsPopularItem { get; set; }

        [DisplayName("Select Services")]
        public int ServicesId { get; set; }

        public virtual Services Services { get; set; }


        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}
