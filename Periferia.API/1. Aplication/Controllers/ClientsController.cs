using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Periferia.API._2._Managers.Interfaces;
using Periferia.API._3._Data.Entities;
using Periferia.API._3._Data.Services;

namespace Periferia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly PeriferiDBContext _context;
        private  IClientManager _manager;

        public ClientsController(PeriferiDBContext context, IClientManager manager)
        {
            _context = context;
            _manager = manager;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients(string param)
        {
            return await _manager.GetItems(param);
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(long id)
        {
            var item = await _manager.GetItem(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client item)
        {
            var response = await _manager.SetItem(item);

            if (response.Id == 0)
            {
                return NoContent();
            }
            else
            {
                return response;
            }
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
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
