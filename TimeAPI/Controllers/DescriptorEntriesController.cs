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
    public class DescriptorEntriesController : ControllerBase
    {
        private readonly ModelContext _context;

        public DescriptorEntriesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/DescriptorMatters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DescriptorEntry>>> GetDescriptorEntries()
        {
            return await _context.DescriptorEntries.ToListAsync();
        }

        // GET: api/DescriptorMatters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DescriptorEntry>> GetDescriptorEntry(int id)
        {
            var descriptorMatter = await _context.DescriptorEntries.FindAsync(id);

            if (descriptorMatter == null)
            {
                return NotFound();
            }

            return descriptorMatter;
        }

        // PUT: api/DescriptorMatters/5
        [HttpPut]
        public async Task<IActionResult> PutDescriptorMatter(int id, [FromBody] DescriptorEntry descriptorEntry)
        {
            if (id != descriptorEntry.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            _context.Entry(descriptorEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorEntryExists(id))
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

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchDescriptorEntry(int id, [FromBody] DescriptorEntry descriptorEntry)
        {
            if (id != descriptorEntry.DescriptorId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            _context.Entry(descriptorEntry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorEntryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        // POST: api/DescriptorMatters
        [HttpPost]
        public async Task<ActionResult<DescriptorEntry>> PostDescriptorEntry(DescriptorEntry descriptorEntry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            _context.DescriptorEntries.Add(descriptorEntry);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DescriptorEntryExists(descriptorEntry.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDescriptorMatter", new { id = descriptorEntry.Id }, descriptorEntry);
        }

        // DELETE: api/DescriptorMatters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DescriptorEntry>> DeleteDescriptorEntry(int id)
        {
            var descriptorEntry = await _context.DescriptorEntries.FindAsync(id);
            if (descriptorEntry == null)
            {
                return NotFound();
            }

            _context.DescriptorEntries.Remove(descriptorEntry);
            await _context.SaveChangesAsync();

            return descriptorEntry;
        }

        private bool DescriptorEntryExists(int id)
        {
            return _context.DescriptorEntries.Any(e => e.Id == id);
        }
    }
}
