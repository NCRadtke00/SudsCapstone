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
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace Sud.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext db;
        private readonly ShoppingCart _shoppingCart;
        //might need to remove this?
        private readonly IWebHostEnvironment _hostEnvironment;

        public OrderRepository(ApplicationDbContext context, ShoppingCart shoppingCart, IWebHostEnvironment hostEnvironment)
        {
            db = context;
            _shoppingCart = shoppingCart;
            //might need to remove this?

            this._hostEnvironment = hostEnvironment;
        }
        public async Task CreateOrderAsync(Models.Order order/*, Models.ImageModel imageModel*/)
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
            {
                //string wwwRootPath = _hostEnvironment.WebRootPath;
                //string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
                //string extension = Path.GetExtension(imageModel.ImageFile.FileName);
                //imageModel.ImageName = fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                //string path = Path.Combine(wwwRootPath + "/Image/", fileName);
                //using (var fileStream = new FileStream(path, FileMode.Create))
                //{
                //    await imageModel.ImageFile.CopyToAsync(fileStream);
                //}
                //db.Add(imageModel);
                
            }
            db.Orders.Add(order);
            await db.SaveChangesAsync();
        }
    }
}
