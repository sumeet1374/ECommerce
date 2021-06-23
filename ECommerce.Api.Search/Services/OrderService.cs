using ECommerce.Api.Search.Inerfaces;
using ECommerce.Api.Search.Models;
using ECommerce.Api.Search.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class OrderService : IOrderService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<OrderService> logger;

        public OrderService(IHttpClientFactory httpClientFactory,ILogger<OrderService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Order> orders, string ErrorMessage)> GetOrdersAsync(int customerId)
        {
            try
            {
                var result = await httpClientFactory.GetAsync<IEnumerable<Order>>("OrderService", $"api/orders/{customerId}");
                return result;
            }
            catch (Exception ex)
            {
                logger?.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
