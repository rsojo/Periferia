using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Periferia.API._2._Managers.Interfaces;
using Periferia.API._3._Data.Entities;

namespace Periferia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SimpleSalesController : ControllerBase
    {
        private readonly ISimpleSaleMAnager _manager;

        public SimpleSalesController(ISimpleSaleMAnager manager)
        {
            _manager = manager;
        }

        // GET: api/SimpleSales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SimpleSale>>> GetProducts(string param)
        {
            return await _manager.GetItems(param);
        }
        // POST: api/SimpleSales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SimpleSale>> PostSimpleSale(SimpleSale item)
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

    }
}
