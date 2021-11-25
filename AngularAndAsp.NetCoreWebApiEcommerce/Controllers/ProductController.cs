using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularAndAsp.NetCoreWebApiEcommerce;
using AngularAndAsp.NetCoreWebApiEcommerce.Models;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;

namespace AngularAndAsp.NetCoreWebApiEcommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        
        public ProductController(ApplicationDBContext context)
        {
            _context = context;
            
        }
        //[Route("api/[controller]")]
        // GET: api/Product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }
        //[Route("api/[controller]")]
        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }
        //[Route("api/[controller]")]
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        //[Route("api/[controller]")]
        // POST: api/Product
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

           

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        ////[Route("api/Product/Upload")]
        //[HttpPost, DisableRequestSizeLimit]

        //public IActionResult Upload()
        //{
           
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        var folderName = Path.Combine("Resources", "Images");
        //        var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

        //        if (file.Length > 0)
        //        {
        //            var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
        //            var fullPath = Path.Combine(pathToSave, fileName);
        //            var dbPath = Path.Combine(folderName, fileName);
                    

        //            using (var stream = new FileStream(fullPath, FileMode.Create))
        //            {
        //                file.CopyTo(stream);

        //            }
        //            return Ok(new { dbPath });
        //        }
        //        else
        //        {
        //            return BadRequest();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"internal server error {ex}");
        //    }

        //}


        //Route("api/[controller]")]
        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var imagePath = Path.Combine(Directory.GetCurrentDirectory(),product.Image);
            if (System.IO.File.Exists(imagePath))
                System.IO.File.Delete(imagePath);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
