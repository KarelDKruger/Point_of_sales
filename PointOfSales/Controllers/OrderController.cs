using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
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
            CustomiseLaptopViewModel model = new CustomiseLaptopViewModel(_configuration);
            model.HddItems = await model.GetHDDsAsync("api/GetHdd");
            model.ColorSelections = await model.GetColorAsync("api/GetColor");
            model.RamItems = await model.GetRamAsync("api/GetRam");
            var test = "";
            return View("CustomizeLaptop", model);
            throw new NotImplementedException();
        }
    }
}
