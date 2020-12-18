using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Stripe;


namespace Sud.Repositories
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Models.Order order/*, Models.ImageModel imageModel*/);
    }
}
