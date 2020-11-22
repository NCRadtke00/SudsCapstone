using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Sud.Models.ViewModels
{
    public class CustomersByPickUpAndDropOffDay
    {
        public SelectList DaySelection { get; set; }
        [Display(Name = "Which day would you like to see?")]
        public string DaySelected { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}
