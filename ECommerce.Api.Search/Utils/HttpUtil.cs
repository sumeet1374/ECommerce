using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerce.Api.Search.Utils
{
    public static class HttpUtil
    {

        public static async Task<(bool IsSuccess,T result,string ErrorMessage)> GetAsync<T>(this IHttpClientFactory factory,string clientName,string url)
        {
            var client = factory.CreateClient(clientName);
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsByteArrayAsync();
                var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                var result = JsonSerializer.Deserialize<T>(content, options);
                return (true, result, null);
            }

            return (false, default(T), response.ReasonPhrase);
        }
    }
}
