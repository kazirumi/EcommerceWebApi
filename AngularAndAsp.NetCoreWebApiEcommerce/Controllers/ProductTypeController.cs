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
    public class ProductTypeController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProductTypeController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/ProductType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductType>>> GetProductTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }

        // GET: api/ProductType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductType>> GetProductType(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);

            if (productType == null)
            {
                return NotFound();
            }

            return productType;
        }

        // PUT: api/ProductType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProductType(int id, ProductType productType)
        {
            if (id != productType.ID)
            {
                return BadRequest();
            }

            _context.Entry(productType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductTypeExists(id))
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

        // POST: api/ProductType
        [HttpPost]
        public async Task<ActionResult<ProductType>> PostProductType(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProductType", new { id = productType.ID }, productType);
        }

        // DELETE: api/ProductType/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductType>> DeleteProductType(int id)
        {
            var productType = await _context.ProductTypes.FindAsync(id);
            if (productType == null)
            {
                return NotFound();
            }

            _context.ProductTypes.Remove(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        private bool ProductTypeExists(int id)
        {
            return _context.ProductTypes.Any(e => e.ID == id);
        }
    }
}
