using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularAndAsp.NetCoreWebApiEcommerce;
using AngularAndAsp.NetCoreWebApiEcommerce.Models;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuantityTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public QuantityTypeController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/QuantityType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QuantityType>>> GetQuantityType()
        {
            return await _context.QuantityType.ToListAsync();
        }

        // GET: api/QuantityType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuantityType>> GetQuantityType(int id)
        {
            var quantityType = await _context.QuantityType.FindAsync(id);

            if (quantityType == null)
            {
                return NotFound();
            }

            return quantityType;
        }

        // PUT: api/QuantityType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuantityType(int id, QuantityType quantityType)
        {
            if (id != quantityType.ID)
            {
                return BadRequest();
            }

            _context.Entry(quantityType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuantityTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/QuantityType
        [HttpPost]
        public async Task<ActionResult<QuantityType>> PostQuantityType(QuantityType quantityType)
        {
            _context.QuantityType.Add(quantityType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuantityType", new { id = quantityType.ID }, quantityType);
        }

        // DELETE: api/QuantityType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuantityType>> DeleteQuantityType(int id)
        {
            var quantityType = await _context.QuantityType.FindAsync(id);
            if (quantityType == null)
            {
                return NotFound();
            }

            _context.QuantityType.Remove(quantityType);
            await _context.SaveChangesAsync();

            return quantityType;
        }

        private bool QuantityTypeExists(int id)
        {
            return _context.QuantityType.Any(e => e.ID == id);
        }
    }
}
