using ECommerce.Api.Search.Inerfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Services
{
    public class SearchService : ISearchService
    {
        private readonly IOrderService orderService;
        private readonly IProuctService productService;
        private readonly ICustomerService customerService;

        public SearchService(IOrderService orderService, IProuctService productService,ICustomerService customerService)
        {
            this.orderService = orderService;
            this.productService = productService;
            this.customerService = customerService;
        }
        public async Task<(bool IsSuccess, dynamic SearchResult)> SearchAsync(int customerId)
        {
            var orderResult = await orderService.GetOrdersAsync(customerId);
            var productResult = await productService.GetProductsAsync();
            var customerResult = await customerService.GetCustomerAsync(customerId);
            
            if(orderResult.IsSuccess)
            {

                foreach(var order in orderResult.orders)
                {
                    foreach(var orderItem in order.Items)
                    {
                        orderItem.ProductName = productResult.IsSuccess? productResult.Products.FirstOrDefault(x => x.Id == orderItem.ProductId)?.Name:"Product Name not available";
                    }
                }
                var result =new { Orders = orderResult.orders, Customer = customerResult.IsSucces ? customerResult.customer : new Models.Customer() { Id = 0, Name = "Customer Details Not Available" } };
                return (true, result);

            }
            return (false,null);
        }
    }
}
