using ECommerce.Api.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Inerfaces
{
    public interface ICustomerService
    {
        Task<(bool IsSucces,Customer customer,string ErrorMessage)> GetCustomerAsync(int customerId);
    }
}
