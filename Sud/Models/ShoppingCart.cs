using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Sud.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sud.Models;
using Microsoft.EntityFrameworkCore;

namespace Sud.Models
{
    public class ShoppingCart
    {
        private readonly ApplicationDbContext db;
        private ShoppingCart(ApplicationDbContext appDbContext)
        {
            db = appDbContext;
        }
        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;
            var context = services.GetService<ApplicationDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", cartId);
            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }
        public async Task AddToCartAsync(Clothes clothes, int amount)
        {
            var shoppingCartItem =
                    await db.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.Clothes.Id == clothes.Id && s.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Clothes = clothes,
                    Amount = 1
                };
                db.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            await db.SaveChangesAsync();
        }
        public async Task<int> RemoveFromCartAsync(Clothes clothes)
        {
            var shoppingCartItem =
                    await db.ShoppingCartItems.SingleOrDefaultAsync(
                        s => s.Clothes.Id == clothes.Id && s.ShoppingCartId == ShoppingCartId);
            var localAmount = 0;
            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    db.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }
            await db.SaveChangesAsync();
            return localAmount;
        }
        public async Task<List<ShoppingCartItem>> GetShoppingCartItemsAsync()
        {
            return ShoppingCartItems ??
                   (ShoppingCartItems = await
                       db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Clothes)
                           .ToListAsync());
        }
        public async Task ClearCartAsync()
        {
            var cartItems = db
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            db.ShoppingCartItems.RemoveRange(cartItems);

            await db.SaveChangesAsync();
        
        }
        public double GetShoppingCartTotal()
        {
            var total = db.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Clothes.Price * c.Amount).Sum();
            return total;
        }
    }
}
