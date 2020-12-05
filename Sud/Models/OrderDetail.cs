using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public double Amount { get; set; }
        public double Price { get; set; }
        [ForeignKey("Clothes")]
        public int ClothesId { get; set; }
        public virtual Clothes Clothes { get; set; }
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
