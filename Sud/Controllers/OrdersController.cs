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
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
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
                return RedirectToAction("CheckoutComplete");
            }
            return View(order);
        }
        public IActionResult CheckoutComplete()
        {
            ViewBag.CheckoutCompleteMessage = $"Thanks for your order, We'll collect your order soon!";
            return View();
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await um.GetUserAsync(HttpContext.User);
            bool isAdmin = await um.IsInRoleAsync(user, "Admin");

            if (isAdmin)
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
            bool isAdmin = userRoles.Any(r => r == "Admin");
            if (orders == null)
            {
                return NotFound();
            }
            if (isAdmin == false)
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
