using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Periferia.MVC.Helpers;
using Periferia.MVC.Models;
using Periferia.MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Periferia.MVC.Services.Implementations
{
    public class ClientService : IClientService
    {
        private readonly ApiUrl _apiUrl;
        HttpClient client = new HttpClient();
        public ClientService(IOptions<ApiUrl> apiUrl)
        {
            _apiUrl = apiUrl.Value;

        }

        public async Task<Response<int>> Delete(long id)
        {
            var response = new Response<int>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var res = await client.DeleteAsync("/api/Clients/" + id.ToString());
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

        public async Task<Response<Client>> GetItem(long id)
        {
            var response = new Response<Client>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var res = await client.GetAsync("/api/Clients/"+id.ToString());
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.UnitResp = JsonConvert.DeserializeObject<Client>(results);
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

        public async Task<Response<Client>> GetItems(string param)
        {
            var response = new Response<Client>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var res = await client.GetAsync("/api/Clients");
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.Lst = JsonConvert.DeserializeObject<List<Client>>(results);
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

        public async Task<Response<Client>> SetItem(Client item)
        {
            var response = new Response<Client>();
            try
            {
                client.BaseAddress = new Uri(_apiUrl.urlBase);
                var content = JsonConvert.SerializeObject(item);
                var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var res = await client.PostAsync("/api/Clients", byteContent);
                if (res.IsSuccessStatusCode)
                {
                    var results = res.Content.ReadAsStringAsync().Result;
                    response.UnitResp = JsonConvert.DeserializeObject<Client>(results);
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
