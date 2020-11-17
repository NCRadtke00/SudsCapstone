using Sud.Data;
using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task CreateOrderAsync(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            decimal totalPrice = 0M;
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
                db.OrderDetails.Add(orderDetail);
            }
            order.OrderTotal = totalPrice;
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }
    }
}
