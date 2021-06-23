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
    public class ProductsService : IProuctService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILogger logger;

        public ProductsService(IHttpClientFactory  httpClientFactory,ILogger<ProductsService> logger)
        {
            this.httpClientFactory = httpClientFactory;
            this.logger = logger;
        }
        public async Task<(bool IsSuccess, IEnumerable<Product> Products, string ErrorMessage)> GetProductsAsync()
        {
            try
            {
                var result = await httpClientFactory.GetAsync<IEnumerable<Product>>("ProductsService", $"api/products");
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
