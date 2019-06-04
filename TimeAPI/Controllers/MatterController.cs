using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeAPI.Models;
using TimeAPI.Extensions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatterController : ControllerBase
    {
        private readonly ModelContext _context;
        
        public MatterController(ModelContext context)
        {
            _context = context;

            if (_context.Matters.Count() == 0)
            {
                //Create a default matter if there are none in the DB
                _context.Matters.Add(new Matter { Name = "Default Matter", Identifier = "00001"});
                _context.SaveChanges();
            }
        }

        // GET: api/matter
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Matter>>> GetMatters()
        {
            return await _context.Matters.ToListAsync();
        }

        // GET: api/matter/{ID}
        [HttpGet("{id}")]
        public async Task<ActionResult<Matter>> GetMatter(long id)
        {
            var Matter = await _context.Matters.FindAsync(id);

            if (Matter == null)
            {
                return NotFound();
            }

            return Matter;
        }

        // POST: api/matter
        [HttpPost]
        public async Task<ActionResult<Matter>> PostMatter([FromBody] Matter matter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            _context.Matters.Add(matter);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMatter), new { id = matter.Id }, matter);
        }

        // PUT: api/matter/ID
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMatter(int id, [FromBody] Matter matter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if (id != matter.Id)
            {
                return BadRequest();
            }

            _context.Entry(matter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PATCH: api/matter/ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchMatter(int id, [FromBody] Matter matter)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if (id != matter.Id)
            {
                return BadRequest();
            }

            _context.Entry(matter).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/matter/ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMatter(long id)
        {
            var matter = await _context.Matters.FindAsync(id);

            if (matter == null)
            {
                return NotFound();
            }

            _context.Matters.Remove(matter);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
