using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sud.Data;
using Sud.Models;
using Sud.Repositories;
using Stripe;
using System.Security.Claims;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Web;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Sud.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        private readonly IOrderRepository or;
        private readonly ShoppingCart sc;
        private readonly ApplicationDbContext db;
        private readonly UserManager<IdentityUser> um;

        public OrdersController(IOrderRepository orderRepository,
            ShoppingCart shoppingCart, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            or = orderRepository;
            sc = shoppingCart;
            db = context;
            um = userManager;
        }
        //add methods to adding photo
        //public async Task<IActionResult> AddPicture()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public async Task<IActionResult> AddPicture([Bind("Title,IamgeFile")] Models.Order order)
        //{
        //    Models.Order orderToAddPictureTo = db.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();

        //    db.Orders.Update(orderToAddPictureTo);
        //    await db.SaveChangesAsync();

        //    return RedirectToAction("MakePayment");
        //}

        //method for adding photo's above
        public async Task<IActionResult> MakePayment(int id, double orderTotal)
        {
            Models.Order order = db.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();
            order.OrderTotal = orderTotal;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MakePayment(IFormCollection collection, double paymentAmount, Models.Order order)
        {
            StripeConfiguration.ApiKey = APIKeys.StripeSecretKey;
            var options = new ChargeCreateOptions
            {
                Amount = (long)paymentAmount * 100,
                Currency = "usd",
                Source = "tok_visa",
                Description = "My First Test Charge (created for API docs)",
            };
            var service = new ChargeService();
            service.Create(options);
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            Models.Order payForOrder = db.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();
            payForOrder.PaymentAmount += paymentAmount;
            db.Orders.Update(payForOrder);
            await db.SaveChangesAsync();
            return RedirectToAction("CheckoutComplete");
        }
        //public IActionResult DisplayOrdertotal(double orderTotal)
        //{
        //    Models.Order order = db.Orders.OrderByDescending(o => o.OrderId).FirstOrDefault();
        //    order.OrderTotal = orderTotal;
        //    return View(); 
        //}
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(Models.Order order)
        {
            string url = $"https://maps.googleapis.com/maps/api/geocode/json?address={order.Address.StreetAddress},+{order.Address.City},+{order.Address.State},{order.Address.ZipCode}&key=AIzaSyDXS87aNNUzLOl40Q1kuMBWqup20n-508M";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                JObject geoCode = JObject.Parse(jsonResult);
                order.Address.Latitude = (double)geoCode["results"][0]["geometry"]["location"]["lat"];

                order.Address.Longitude = (double)geoCode["results"][0]["geometry"]["location"]["lng"];
            }
            var userId = um.GetUserId(HttpContext.User);
            order.UserId = userId;
            var items = await sc.GetShoppingCartItemsAsync();
            sc.ShoppingCartItems = items;
            if (sc.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty.");
            }
            if (ModelState.IsValid)
            {
                await or.CreateOrderAsync(order);
                await sc.ClearCartAsync();
                return RedirectToAction("MakePayment");//Change this to add photo have the save for add photo redirect to make payment
            }
            return View(order);
        }

        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = $"Thanks you for your order, We'll collect your order as requested!";
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await um.GetUserAsync(HttpContext.User);
            bool isEmployee = await um.IsInRoleAsync(user, "Employee");
            if (isEmployee)
            {
                var allOrders = await db.Orders.Include(o => o.OrderLines).Include(o => o.User).ToListAsync();
                return View(allOrders);
            }
            else
            {
                var orders = await db.Orders.Include(o => o.OrderLines).Include(o => o.User)
                    .Where(r => r.User == user).ToListAsync();
                return View(orders);
            }
        }
        [Authorize]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var orders = await db.Orders.Include(o => o.OrderLines).Include(o => o.User)
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
            var orderDetailsList = db.OrderDetails.Include(o => o.Clothes).Include(o => o.Order)
                .Where(x => x.OrderId == orders.OrderId);
            ViewBag.OrderDetailsList = orderDetailsList;
            return View(orders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {

            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Employee")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await db.Orders.Include(o => o.User)
                .SingleOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }
        [Authorize(Roles = "Employee")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await db.Orders.SingleOrDefaultAsync(m => m.OrderId == id);
            db.Orders.Remove(order);
            await db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
