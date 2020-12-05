using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sud.Models
{
    public class PickUpDay
    {
        public static List<SelectListItem> PickupDay = new List<SelectListItem>()
        {
            new SelectListItem() { Text="Monday", Value="Monday" },
            new SelectListItem() { Text="Tuesday", Value="Tuesday" },
            new SelectListItem() { Text="Wednesday", Value="Wednesday" },
            new SelectListItem() { Text="Thursday", Value="Thursday" },
            new SelectListItem() { Text="Friday", Value="Friday" },
            new SelectListItem() { Text="Saturday", Value="Saturday" },
            new SelectListItem() { Text="Sunday", Value="Sunday" },
        };
    }
}