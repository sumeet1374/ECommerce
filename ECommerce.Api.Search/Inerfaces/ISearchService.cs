﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Inerfaces
{
    public interface ISearchService
    {
       Task<(bool IsSuccess,dynamic SearchResult)>  SearchAsync(int customerId);
    }
}
