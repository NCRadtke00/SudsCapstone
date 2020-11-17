using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Models.ViewModels
{
    public class SearchClothesViewModel
    {
        [Required]
        [DisplayName("Serach")]
        public string SearchText { get; set; }
        public IEnumerable<Clothes> ClothesList { get; set; }
    }
}
