using Sud.Data;
using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Repositories
{
    public class OrderRepository
    {
        private readonly ApplicationDbContext db;
        private readonly ShoppingCart _shoppingCart;
        public OrderRepository(ApplicationDbContext context, ShoppingCart shoppingCart)
        {
            db = context;
            _shoppingCart = shoppingCart;
        }
    }
}
