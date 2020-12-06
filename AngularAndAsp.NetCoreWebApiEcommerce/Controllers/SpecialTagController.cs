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
    public class SpecialTagController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public SpecialTagController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/SpecialTag
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SpecialTag>>> GetSpecialTag()
        {
            return await _context.SpecialTag.ToListAsync();
        }

        // GET: api/SpecialTag/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SpecialTag>> GetSpecialTag(int id)
        {
            var specialTag = await _context.SpecialTag.FindAsync(id);

            if (specialTag == null)
            {
                return NotFound();
            }

            return specialTag;
        }

        // PUT: api/SpecialTag/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecialTag(int id, SpecialTag specialTag)
        {
            if (id != specialTag.ID)
            {
                return BadRequest();
            }

            _context.Entry(specialTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecialTagExists(id))
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

        // POST: api/SpecialTag
        [HttpPost]
        public async Task<ActionResult<SpecialTag>> PostSpecialTag(SpecialTag specialTag)
        {
            _context.SpecialTag.Add(specialTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecialTag", new { id = specialTag.ID }, specialTag);
        }

        // DELETE: api/SpecialTag/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SpecialTag>> DeleteSpecialTag(int id)
        {
            var specialTag = await _context.SpecialTag.FindAsync(id);
            if (specialTag == null)
            {
                return NotFound();
            }

            _context.SpecialTag.Remove(specialTag);
            await _context.SaveChangesAsync();

            return specialTag;
        }

        private bool SpecialTagExists(int id)
        {
            return _context.SpecialTag.Any(e => e.ID == id);
        }
    }
}
