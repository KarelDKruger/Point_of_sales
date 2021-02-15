using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public IEnumerable<SelectListItem> HddItems { get; set; }
        public IEnumerable<SelectListItem> ColorSelections { get; set; }
        public IEnumerable<SelectListItem> RamItems { get; set; }

        public LaptopItem LaptopSelectedItem { get; set; }
        public HddItem HddSelectedItem { get; set; }
        public ColorSelection ColorSelectedSelection { get; set; }
        public RamItem RamSelectedItem { get; set; }

        public CustomiseLaptopViewModel(IConfiguration configuration)
        {
            _configuration = configuration;
            // populate lists

            HddItems = new List<SelectListItem>();
            ColorSelections = new List<SelectListItem>();
            RamItems = new List<SelectListItem>();

            // get values from api
            //client.BaseAddress = new Uri(_configuration["APIUrl"]);// TODO: look into the problem with the json deserializes
            client.BaseAddress = new Uri("https://localhost:44337/");// temp solution
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<SelectListItem>> GetHDDsAsync(string path)
        {
            List<HddItem> hdds = new List<HddItem>();
            List<SelectListItem> selectedList = new List<SelectListItem>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                hdds = JsonConvert.DeserializeObject<List<HddItem>>(
                    await response.Content.ReadAsStringAsync());
                selectedList = hdds.OrderBy(c => c.Id)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name + " " + c.HddSize
                    }).ToList();
            }
            return selectedList;
        }

        public async Task<IEnumerable<SelectListItem>> GetRamAsync(string path)
        {
            List<RamItem> ramItems = new List<RamItem>();
            List<SelectListItem> selectedList = new List<SelectListItem>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                ramItems = JsonConvert.DeserializeObject<List<RamItem>>(
                    await response.Content.ReadAsStringAsync());
                selectedList = ramItems.OrderBy(c => c.Id)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name + " " + c.RamSize
                    }).ToList();
            }
            return selectedList;
        }

        public async Task<IEnumerable<SelectListItem>> GetColorAsync(string path)
        {

            List<ColorSelection> colorSelections = new List<ColorSelection>();
            List<SelectListItem> selectedList = new List<SelectListItem>();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                colorSelections = JsonConvert.DeserializeObject<List<ColorSelection>>(
                    await response.Content.ReadAsStringAsync());
                selectedList = colorSelections.OrderBy(c => c.Id)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Name
                    }).ToList();
            }
            // convert items to selected list
            return selectedList;
        }

        public async Task<LaptopItem> GetLaptopsAsync(string path)
        {
            LaptopItem laptop = new LaptopItem();
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                laptop = JsonConvert.DeserializeObject<LaptopItem>(
                    await response.Content.ReadAsStringAsync());
            }
            return laptop;
        }
    }
}
