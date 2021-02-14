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
    public class GetColorController : ControllerBase
    {
        private readonly DataContext _context;
        public GetColorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColorSelection>>> GetColor() // using american spelling as it is more universal for ide
        {
            return await _context.ColorSelections.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColorSelection>> GetColor(int id)
        {
            return await _context.ColorSelections.FindAsync(id);
        }
    }
}
