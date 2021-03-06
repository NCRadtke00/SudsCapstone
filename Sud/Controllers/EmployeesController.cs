﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<IdentityUser> um;

        public EmployeeController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _db = context;
            um = userManager;
        }

        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _db.Employee.Where(c => c.IdentityUserId == userId).SingleOrDefault();

            if (employee == null)
            {
                return RedirectToAction("Create");

            }
            UpdateDatabase();
            var customers = GetCustomersOrders(employee);
            return View("ViewTodaysOrders", customers);

        }
        public ActionResult Create()
        {
            Employee employee = new Employee();
            return View(employee);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _db.Add(employee);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }
        public async Task<IActionResult> ViewOrdersByDay(string dayOfWeek)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _db.Employee.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            var orders = GetTodaysOrders(employee, dayOfWeek);
            return View("ViewAllOrders", orders);
        }
        public async Task<IActionResult> ViewAllOrders(int? id)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _db.Employee.Where(e => e.IdentityUserId == userId).FirstOrDefault();
            var orders = _db.Orders.Include(o => o.Address).Where(o => o.Address.ZipCode == employee.ZipCode).ToList();
            return View("ViewAllOrders", orders);
        }
        public async Task<IActionResult> OrderDetails(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var orders = await _db.Orders.Include(o => o.OrderLines).Include(o => o.User)
                .SingleOrDefaultAsync(m => m.OrderId == id);
            var user = await um.GetUserAsync(HttpContext.User);
            var userRoles = await um.GetRolesAsync(user);
            bool isEmployee = userRoles.Any(r => r == "Employee");
            if (orders == null)
            {
                return NotFound();
            }
            if (isEmployee == false)
            {
                var userId = um.GetUserId(HttpContext.User);
                if (orders.UserId != userId)
                {
                    return BadRequest("You do not have permissions to view this order.");
                }
            }
            var orderDetailsList = _db.OrderDetails.Include(o => o.Clothes).Include(o => o.Order)
                .Where(x => x.OrderId == orders.OrderId);
            ViewBag.OrderDetailsList = orderDetailsList;
            return View(orders);
        } 
        public async Task<IActionResult> ConfirmPickup(int? id)
        {
            var order = _db.Orders.Where(o => o.OrderId == id).FirstOrDefault();
            CompletePickUp(order);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private static void CompletePickUp(Order order)
        {
            order.ConfirmPickUp = true;
            order.StatusBar = 50;
        }
        public async Task<IActionResult> ConfirmDropOff(int? id)
        {
            var order = _db.Orders.Where(c => c.OrderId == id).FirstOrDefault();
            CompleteDropOff(order);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private static void CompleteDropOff(Order order)
        {
            order.ConfirmDropoff = true;
            order.StatusBar = 100;
        }
        public async Task<IActionResult> ConfirmCleaning(int? id)
        {
            var order = _db.Orders.Where(c => c.OrderId == id).FirstOrDefault();
            CompleteCleaning(order);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        private static void CompleteCleaning(Order order)
        {
            order.ConfirmCleaning = true;
            order.StatusBar = 75;
        }


        private List<Order> GetCustomersOrders(Employee employee)
        {
            var orders = GetTodaysOrders(employee);
            orders = RemoveCompletedOrders(orders);
            return orders;
        }

        private List<Order> RemoveCompletedOrders(List<Order> orders)
        {
            foreach (Order order in orders.ToList())
            {
                if (order.ConfirmPickUp == true)
                {
                    orders.Remove(order);
                }
                else if (order.ConfirmDropoff == true)
                {
                    orders.Remove(order);
                }
            }
            return orders;
        }

        private List<Order> GetTodaysOrders(Employee employee)
        {
            List<Order> orders = new List<Order>();

            foreach (Order order in _db.Orders.Include(o => o.Address))
            {
                if (order.Address.ZipCode == employee.ZipCode && order.PickUpDay == DateTime.Now.DayOfWeek.ToString() && order.ConfirmPickUp == false)
                {
                    orders.Add(order);
                }
                if (order.Address.ZipCode == employee.ZipCode && order.DropOffDay == DateTime.Now.DayOfWeek.ToString() && order.ConfirmDropoff == false)
                {
                    orders.Add(order);
                }

            }
             return orders;
        }
        private List<Order> GetTodaysOrders(Employee employee, string dayOfWeek)
        {
            List<Order> orders = new List<Order>();
            foreach (Order order in _db.Orders.Include(c => c.Address))
            {
                if (order.Address.ZipCode == employee.ZipCode && order.PickUpDay == dayOfWeek)
                {
                    orders.Add(order);
                }
                if (order.Address.ZipCode == employee.ZipCode && order.DropOffDay == dayOfWeek)
                {
                    orders.Add(order);
                }
            }
            return orders;
        }
        private void UpdateDatabase()
        {
            foreach (Order order in _db.Orders)
            {
                if (order.PickUpDay.Equals(DateTime.Now.AddDays(-1).DayOfWeek.ToString()))
                {
                    _db.Update(order);
                }
                if (order.DropOffDay.Equals(DateTime.Now.AddDays(-1).DayOfWeek.ToString()))
                {
                    _db.Update(order);
                }
            }
            _db.SaveChanges();
        }
    }
}
