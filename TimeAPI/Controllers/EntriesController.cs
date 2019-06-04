using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeAPI.Extensions;
using TimeAPI.Models;

namespace TimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly ModelContext _context;

        public EntriesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Entries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Entry>>> GetEntries()
        {
            return await _context.Entries.ToListAsync();
        }

        // GET: api/Entries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Entry>> GetEntry(long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var entry = await _context.Entries.FindAsync(id);

            if (entry == null)
            {
                return NotFound();
            }

            return entry;
        }

        // PUT: api/Entries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntry(long id, Entry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if (id != entry.Id)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
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

        // POST: api/Entries
        [HttpPost]
        public async Task<ActionResult<Entry>> PostEntry(Entry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            _context.Entries.Add(entry);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEntry", new { id = entry.Id }, entry);
        }

        // PATCH: api/Entries/ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchEntry(int id, [FromBody] Entry entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if (id != entry.Id)
            {
                return BadRequest();
            }

            _context.Entry(entry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    return NoContent();
                    throw;
                }
            }
        }

        // DELETE: api/Entries/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Entry>> DeleteEntry(long id)
        {
            var entry = await _context.Entries.FindAsync(id);
            if (entry == null)
            {
                return NotFound();
            }

            _context.Entries.Remove(entry);
            await _context.SaveChangesAsync();

            return entry;
        }

        private bool EntryExists(long id)
        {
            return _context.Entries.Any(e => e.Id == id);
        }
    }
}
