using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PointOfSaleAPI.Entities;

namespace PointOfSales.ViewModels
{
    public class OrderViewModel
    {
        private IConfiguration _configuration;

        static HttpClient client = new HttpClient();
        public List<SalesItem> SalesItems { get; set; }

        // set gettters to get items from api
        public List<LaptopItem> LaptopItems { get; set; }

        public OrderViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
            // populate lists
            LaptopItems =new List<LaptopItem>();
           

            // get values from api
            client.BaseAddress = new Uri(_configuration["APIUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<LaptopItem>> GetLaptopsAsync(string path)
        {
            List<LaptopItem> laptops = new List<LaptopItem>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                laptops = JsonConvert.DeserializeObject<List<LaptopItem>>(
                    await response.Content.ReadAsStringAsync());
            }
            return laptops;
        }
        
    }
}
