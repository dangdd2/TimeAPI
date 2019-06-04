using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ModelContext _context;
        
        public ClientController(ModelContext context)
        {
            _context = context;

            if (_context.Clients.Count() == 0)
            {
                //Create a default client if there are none in the DB
                _context.Clients.Add(new Client { Name = "Default Client", Identifier="0000001" });
                _context.SaveChanges();
            }
        }

        // GET: api/client
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        // GET: api/client/{ID}
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(long id)
        {
            var Client = await _context.Clients.FindAsync(id);

            if (Client == null)
            {
                return NotFound();
            }

            return Client;
        }

        // POST: api/client
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetClient), new { id = client.Id }, client);
        }

        // PUT: api/client/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(long id, Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/client/ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchClient(long id, [FromBody] Client client)
        {
            if (id != client.Id)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/client/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
