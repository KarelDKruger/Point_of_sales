using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PointOfSaleAPI.Data;
using PointOfSaleAPI.Entities;

namespace PointOfSaleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetLaptopBrandsController : ControllerBase
    {
        private readonly DataContext _context;
        public GetLaptopBrandsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LaptopItem>>> GetLaptopBrands()
        {
            return await _context.LaptopItems.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LaptopItem>> GetLaptopBrands(int id)
        {
            return await _context.LaptopItems.FindAsync(id);
        }
    }
}
