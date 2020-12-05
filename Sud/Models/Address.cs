using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Sud.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
