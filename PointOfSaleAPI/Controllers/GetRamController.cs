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
    public class GetRamController : ControllerBase
    {
        private readonly DataContext _context;
        public GetRamController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RamItem>>> GetRam()
        {
            return await _context.RamItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RamItem>> GetRam(int id)
        {
            return await _context.RamItems.FindAsync(id);
        }
    }
}
