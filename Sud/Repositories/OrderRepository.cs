using Sud.Data;
using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;
using Microsoft.EntityFrameworkCore;
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

namespace Sud.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext db;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            db = context;
            _shoppingCart = shoppingCart;
        }
        public async Task CreateOrderAsync(Models.Order order)
        {
            order.OrderPlaced = DateTime.Now;
            double totalPrice = 0;
            var shoppingCartItems = _shoppingCart.ShoppingCartItems;
            foreach (var shoppingCartItem in shoppingCartItems)
            {
                var orderDetail = new OrderDetail()
                {
                    Amount = shoppingCartItem.Amount,
                    ClothesId = shoppingCartItem.Clothes.Id,
                    Order = order,
                    Price = shoppingCartItem.Clothes.Price,
                };
                totalPrice += orderDetail.Price * orderDetail.Amount;
                order.OrderTotal = totalPrice;
                db.OrderDetails.Add(orderDetail);
            }
            order.OrderTotal = totalPrice;
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }
    }
}
