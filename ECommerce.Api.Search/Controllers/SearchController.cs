using ECommerce.Api.Search.Inerfaces;
using ECommerce.Api.Search.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Controllers
{
    [ApiController]
    [Route("api/Search")]
    public class SearchController:ControllerBase 
    {
        private readonly ISearchService service;

        public SearchController(ISearchService service)
        {
            this.service = service;
           
        }

        [HttpPost]
        public  async Task<IActionResult> SearchAsync(SearchTerm term)
        {
            var result = await service.SearchAsync(term.CustomerId);
            if(result.IsSuccess)
            {
                return Ok(result.SearchResult);
            }

            return NotFound("Not found");
        }
    }
}
