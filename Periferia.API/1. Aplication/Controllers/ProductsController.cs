using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Periferia.API._2._Managers.Interfaces;
using Periferia.API._3._Data.Entities;

namespace Periferia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductManager _manager;

        public ProductsController(IProductManager manager)
        {
            _manager = manager;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(string param)
        {
            return await _manager.GetItems(param);
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(long id)
        {
            var item = await _manager.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product item)
        {
            var response = await _manager.SetItem(item);

            if (response.Id == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok();
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var item = await _manager.GetItem(id);
            if (item == null)
            {
                return NotFound();
            }

            var result = await _manager.Delete(id);
            if (result == 1)
            {
                return Ok();
            }

            return NoContent();
        }
    }
}
