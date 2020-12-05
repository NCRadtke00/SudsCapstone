using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace Sud.Models
{
    public class DropOffDay
    {
        public static List<SelectListItem> DropoffDay = new List<SelectListItem>()
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