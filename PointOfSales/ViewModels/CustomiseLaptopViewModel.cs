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
    public class CustomiseLaptopViewModel
    {
        private IConfiguration _configuration;

        static HttpClient client = new HttpClient();
        public List<SalesItem> SalesItems { get; set; }

        // set gettters to get items from api
        public List<HddItem> HddItems { get; set; }
        public List<ColorSelection> ColorSelections { get; set; }
        public List<RamItem> RamItems { get; set; }

        public LaptopItem LaptopSelectedItem { get; set; }
        public HddItem HddSelectedItem { get; set; }
        public ColorSelection ColorSelectedSelection { get; set; }
        public RamItem RamSelectedItem { get; set; }

        public CustomiseLaptopViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
            // populate lists
            
            HddItems = new List<HddItem>();
            ColorSelections = new List<ColorSelection>();
            RamItems = new List<RamItem>();

            // get values from api
            client.BaseAddress = new Uri(_configuration["APIUrl"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        
        public async Task<List<HddItem>> GetHDDsAsync(string path)
        {
            List<HddItem> hdds = new List<HddItem>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                hdds = JsonConvert.DeserializeObject<List<HddItem>>(
                    await response.Content.ReadAsStringAsync());
            }
            return hdds;
        }

        public async Task<List<RamItem>> GetRamAsync(string path)
        {
            List<RamItem> ramItems = new List<RamItem>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ramItems = JsonConvert.DeserializeObject<List<RamItem>>(
                    await response.Content.ReadAsStringAsync());
            }
            return ramItems;
        }

        public async Task<List<ColorSelection>> GetColorAsync(string path)
        {
            List<ColorSelection> colorSelections = new List<ColorSelection>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                colorSelections = JsonConvert.DeserializeObject<List<ColorSelection>>(
                    await response.Content.ReadAsStringAsync());
            }
            return colorSelections;
        }
    }
}
