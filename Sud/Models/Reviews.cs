using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Models
{
    public class Reviews
    {
        [Key]
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [RegularExpression("([a-zA-Z0-9 .&'-]+)", ErrorMessage = "The field Title should only include letters and number.")]
        [DataType(DataType.Text)]
        [Required]
        public string Title { get; set; }

        [StringLength(500, MinimumLength = 2)]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Description { get; set; }

        [Range(1, 5)]
        public int Grade { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("Select Clothing")]
        [ForeignKey("Clothes")]
        public int ClothesId { get; set; }

        public virtual Clothes Clothes { get; set; }
        [ForeignKey("IdentityUser")]

        public string IdentityUserId { get; set; }

        public IdentityUser User { get; set; }
    }
}
