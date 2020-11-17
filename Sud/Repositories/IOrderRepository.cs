﻿using Sud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sud.Repositories
{
    interface IOrderRepository
    {
        Task CreateOrderAsync(Order order);
    }
}