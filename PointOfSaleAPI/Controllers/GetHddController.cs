using Microsoft.AspNetCore.Http;
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
    public class GetHddController : ControllerBase
    {
        private readonly DataContext _context;
        public GetHddController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HddItem>>> GetHdds()
        {
            return await _context.HddItems.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HddItem>> GetHdds(int id)
        {
            return await _context.HddItems.FindAsync(id);
        }
    }
}
