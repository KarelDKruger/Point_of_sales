using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PointOfSaleAPI.Entities;
using PointOfSales.ViewModels;

namespace PointOfSales.Controllers
{
    public class OrderController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        private IConfiguration _configuration;

        public OrderController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Detail()
        {
            OrderViewModel model = new OrderViewModel(_configuration);
            model.LaptopItems = await model.GetLaptopsAsync("api/GetLaptopBrands");

            var str = JsonConvert.SerializeObject(new CustomiseLaptopViewModel(_configuration));
            HttpContext.Session.SetString("CartItems", str);

            return View(model);
        }

        // submit
        [HttpPost]
        public IActionResult CheckOut(CustomiseLaptopViewModel model)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<IActionResult> AddItemToCart(int submit)// Update Cart
        {
            //HttpContext.Session.Set("","");
            //Session["userId"] = 1;
            var existingStr = HttpContext.Session.GetString("CartItems");
            var sessionModel = JsonConvert.DeserializeObject<CustomiseLaptopViewModel>(existingStr);
            if (sessionModel == null)
            {
                CustomiseLaptopViewModel model = new CustomiseLaptopViewModel(_configuration);

                model.HddItems = await model.GetHDDsAsync("api/GetHdd");
                model.ColorSelections = await model.GetColorAsync("api/GetColor");
                model.RamItems = await model.GetRamAsync("api/GetRam");
                model.LaptopSelectedItem = await model.GetLaptopsAsync("api/GetLaptopBrands/" + submit.ToString());
                var test = "";
                var str = JsonConvert.SerializeObject(model);
                HttpContext.Session.SetString("CartItems", str);
                return View("CustomizeLaptop", model);
            }
            else
            {
                sessionModel.HddItems = await sessionModel.GetHDDsAsync("api/GetHdd");
                sessionModel.ColorSelections = await sessionModel.GetColorAsync("api/GetColor");
                sessionModel.RamItems = await sessionModel.GetRamAsync("api/GetRam");
                var test = "";
                var str = JsonConvert.SerializeObject(sessionModel);
                HttpContext.Session.SetString("CartItems", str);
                return View("CustomizeLaptop", sessionModel);
            }
        }

        public IActionResult SaveItemToCart(CustomiseLaptopViewModel model)
        {
            var existingStr = HttpContext.Session.GetString("CartItems");
            var sessionModel = JsonConvert.DeserializeObject<CustomiseLaptopViewModel>(existingStr);
            if (sessionModel == null)
            {
                throw new Exception("Something went wrong.");
            }
            else
            {
                sessionModel.SalesItems.Add(new SalesItem
                {
                    Color = model.ColorSelectedSelection,
                    Hdd = model.HddSelectedItem,
                    Ram = model.RamSelectedItem,
                    Laptop = model.LaptopSelectedItem,
                    CostExcVat = model.ColorSelectedSelection.Cost + model.HddSelectedItem.Cost + model.RamSelectedItem.Cost + model.LaptopSelectedItem.Cost,
                    CostIncVat = (model.ColorSelectedSelection.Cost + model.HddSelectedItem.Cost + model.RamSelectedItem.Cost + model.LaptopSelectedItem.Cost) * 1.15M,
                    
                });
            }
            return View("Detail");
        }
    }
}
