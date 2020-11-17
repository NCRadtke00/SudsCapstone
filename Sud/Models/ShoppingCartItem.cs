using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Clothes Clothes { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }
    }
}
