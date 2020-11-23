using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using Sud.Models.ViewModels;

namespace Sud.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeController(ApplicationDbContext context)
        {
            _db = context;
        }

        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _db.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            ResetPickUp();

            if (employee == null)
            {
                return RedirectToAction("Create");

            }
            else
            {
                var customers = _db.Customer.Include(c => c.PickUpDay).ToList();
                var customersInEmployeeZipCode = customers.Where(c => c.ZipCode == employee.ZipCode && c.ConfirmPickUp == false && c.ConfirmDropoff == false).ToList();
                var dayOfWeekString = DateTime.Now.DayOfWeek.ToString();
                var todayString = DateTime.Today.ToString();
                var today = DateTime.Today;
                var customersInEmployeeZipCodeAndToday = customersInEmployeeZipCode.Where(c => c.PickUpDay.Date == dayOfWeekString || c.DropOffDay.Date == dayOfWeekString).ToList();
                return View(customersInEmployeeZipCodeAndToday);
            }
        }

        public ActionResult FilterResults() // get
        {
            CustomersByPickUpAndDropOffDay customersList = new CustomersByPickUpAndDropOffDay();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _db.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var customers = _db.Customer.Include(c => c.PickUpDay).Include(c => c.DropOffDay).ToList();
            customersList.Customers = customers.Where(c => c.ZipCode == employee.ZipCode).ToList();
            customersList.DaySelection = new SelectList(_db.PickUpDays, "Date", "Date");
            customersList.DaySelection = new SelectList(_db.DropOffDays, "Date", "Date");
            return View(customersList);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FilterResults(CustomersByPickUpAndDropOffDay customer)
        {
            CustomersByPickUpAndDropOffDay customersList = new CustomersByPickUpAndDropOffDay();
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _db.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            var selected = customer.DaySelected;
            var customers = _db.Customer.Include(c => c.PickUpDay).Include(c => c.DropOffDay).ToList();
            customersList.Customers = customers.Where(c => c.ZipCode == employee.ZipCode && c.PickUpDay.Date == selected && c.DropOffDay.Date == selected).ToList();
            customersList.DaySelection = new SelectList(_db.PickUpDays, "Date", "Date");
            customersList.DaySelection = new SelectList(_db.DropOffDays, "Date", "Date");
            return View("FilterResults", customersList);
        }

        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _db.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(employee);
            }
        }

        private void ResetPickUp()
        {
            var customers = _db.Customer.Include(m => m.PickUpDay).ToList();
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            foreach (Customer customer in customers)
            {
                if (customer.DatePickedUp == yesterday)
                {
                    customer.ConfirmPickUp = false;
                }
            }
        }
        private void ResetDropOff()
        {
            var customers = _db.Customer.Include(m => m.DropOffDay).ToList();
            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);
            foreach (Customer customer in customers)
            {
                if (customer.DateDropoff == yesterday)
                {
                    customer.ConfirmDropoff = false;
                }
            }
        }
        public ActionResult ConfirmPickUp(int id)
        {
            var customer = _db.Customer.Where(c => c.Id == id).Single();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmPickUp(Customer customer)
        {
            try
            {
                if (customer.ConfirmPickUp == true)
                {
                    customer.DatePickedUp = DateTime.Today;
                    
                }
                _db.Customer.Update(customer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
        public ActionResult ConfirmDropoff(int id)
        {
            var customer = _db.Customer.Where(c => c.Id == id).Single();
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmDropoff(Customer customer)
        {
            try
            {
                if (customer.ConfirmDropoff == true)
                {
                    customer.DateDropoff = DateTime.Today;
                }
                _db.Customer.Update(customer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }
        //public ActionResult Map(int id) // for adding google maps
        //{
        //    CustomerAddress address = new CustomerAddress();
        //    var locationService = new GoogleLocationService(apikey: "AIzaSyC8E3PXqKgVRYxAwL7v3V_1K7Af6EnzHX8"); // hide this api key from project
        //    var customer = _db.Customer.Find(id);
        //    address.StreetAddress = customer.StreetAddress;
        //    address.City = customer.City;
        //    address.State = customer.State;
        //    address.ZipCode = customer.ZipCode;
        //    var customerAddress = $"{address.StreetAddress}{address.City}{address.State}{address.ZipCode}";
        //    var pin = locationService.GetLatLongFromAddress(customerAddress);
        //    address.Longitude = pin.Longitude;
        //    address.Latitude = pin.Latitude;
        //    return View(address);
        //}
    }
}
