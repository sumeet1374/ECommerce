using ECommerce.Api.Search.Inerfaces;
using ECommerce.Api.Search.Models;
using ECommerce.Api.Search.Utils;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger<CustomerService> logger;

        public CustomerService(IHttpClientFactory httpClientFactory,ILogger<CustomerService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSucces, Customer customer, string ErrorMessage)> GetCustomerAsync(int customerId)
        {
            try
            {
                var result = await httpClientFactory.GetAsync<Customer>("CustomersService", $"api/customers/{customerId}");
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
