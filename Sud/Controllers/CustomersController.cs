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

namespace Sud.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customer.Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return View("Details", customer);
            }
        }
        public IActionResult Details(Customer customer)
        {
            customer.PickUpDay = _context.PickUpDays.Find(customer.PickUpDayId);
            customer.DropOffDay = _context.DropOffDays.Find(customer.DropOffDayId);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        public IActionResult Create() //get
        {
            var days = _context.PickUpDays.ToList();
            var dates = _context.DropOffDays.ToList();
            
            Customer customer = new Customer()
            {
                Days = new SelectList(days, "Id", "Date"),
                Dates = new SelectList(dates, "Id", "Date")
            };
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer customer) // post
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                customer.IdentityUserId = userId;
                customer.PickUpDay = _context.PickUpDays.Find(customer.PickUpDayId);
                customer.DropOffDay = _context.DropOffDays.Find(customer.DropOffDayId);
                _context.Add(customer);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(customer);
            }

        }
        public IActionResult Edit(int? id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            var days = _context.PickUpDays.ToList();
            customer.Days = new SelectList(days, "Id", "Date");
            var dates = _context.DropOffDays.ToList();
            customer.Dates = new SelectList(dates, "Id", "Date");
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer customer)
        {
            try
            {
                _context.Customer.Update(customer);
                _context.SaveChanges();
                return RedirectToAction("Details", customer);
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
