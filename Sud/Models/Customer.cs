using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        //adding below
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        //[ForeignKey("PickUpDay")]
        //[Display(Name = "Pickup Day")]
        //public int PickUpDayId { get; set; }
        //public PickUpDay PickUpDay { get; set; }
        //[ForeignKey("DropOffDay")]
        //[Display(Name = "Drop off Day")]
        //public int DropOffDayId { get; set; }
        //public DropOffDay DropOffDay { get; set; }
        //[NotMapped]
        //public SelectList Days { get; set; }
        //[NotMapped]
        //public SelectList Dates { get; set; }
        [Display(Name = "Check the box to confirm order has been pick up!")]
        public bool ConfirmPickUp { get; set; }
        [Display(Name = "Check the box to confirm order has been dropped off!")]
        public bool ConfirmDropoff { get; set; }
        [NotMapped]
        public DateTime? DatePickedUp { get; set; }
        [NotMapped]
        public DateTime? DateDropoff { get; set; }

        //adding above
        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
