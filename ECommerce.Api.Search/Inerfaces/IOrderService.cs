﻿using ECommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Inerfaces
{
    public interface IOrderService
    {
        Task<(bool IsSuccess, IEnumerable<Order> orders,string ErrorMessage)> GetOrdersAsync(int customerId);
    }
}
