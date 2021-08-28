using Microsoft.Extensions.Options;
using Periferia.MVC.Helpers;
using Periferia.MVC.Services.Interfaces;
using Periferia.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Periferia.MVC.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly ApiUrl _apiUrl;
        HttpClient client = new HttpClient();
        public ProductService(IOptions<ApiUrl> apiUrl)
        {
            _apiUrl = apiUrl.Value;

        }

        public async Task<Response<int>> Delete(long id)
        {
            var response = new Response<int>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var res = await client.DeleteAsync("/api/Products/" + id.ToString());
                if (res.IsSuccessStatusCode)
                {
                    response.UnitResp = 1;
                }
                else
                {
                    response.Error = true;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
            }
            return response;
        }

        public async Task<Response<Product>> GetItem(long id)
        {
            var response = new Response<Product>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var res = await client.GetAsync("/api/Products/" + id.ToString());
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.UnitResp = JsonConvert.DeserializeObject<Product>(results);
                }
                else
                {
                    response.Error = true;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
            }
            return response;
        }

        public async Task<Response<Product>> GetItems(string param)
        {
            var response = new Response<Product>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var res = await client.GetAsync("/api/Products");
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.Lst = JsonConvert.DeserializeObject<List<Product>>(results);
                }
                else
                {
                    response.Error = true;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
            }
            return response;
        }

        public async Task<Response<Product>> SetItem(Product item)
        {
            var response = new Response<Product>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var content = JsonConvert.SerializeObject(item);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var res = await client.PostAsync("/api/Products", byteContent);
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.UnitResp = JsonConvert.DeserializeObject<Product>(results);
                }
                else
                {
                    response.Error = true;
                }
            }
            catch (Exception ex)
            {
                response.Error = true;
            }
            return response;
        }
    }
}
