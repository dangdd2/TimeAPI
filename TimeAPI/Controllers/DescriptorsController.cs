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
    public class DescriptorsController : ControllerBase
    {
        private readonly ModelContext _context;

        public DescriptorsController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Descriptors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Descriptor>>> GetDescriptors()
        {
            return await _context.Descriptors.ToListAsync();
        }

        // GET: api/Descriptors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Descriptor>> GetDescriptor(long id)
        {
            var descriptor = await _context.Descriptors.FindAsync(id);

            if (descriptor == null)
            {
                return NotFound();
            }

            return descriptor;
        }

        // PUT: api/Descriptors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDescriptor(long id, Descriptor descriptor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if (id != descriptor.Id)
            {
                return BadRequest();
            }

            _context.Entry(descriptor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorExists(id))
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

        // POST: api/Descriptors
        [HttpPost]
        public async Task<ActionResult<Descriptor>> PostDescriptor([FromBody] Descriptor descriptor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            _context.Descriptors.Add(descriptor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDescriptor", new { id = descriptor.Id }, descriptor);
        }

        // PATCH: api/Descriptors/ID
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchDescriptor(int id, [FromBody] Descriptor descriptor)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            if (id != descriptor.Id)
            {
                return BadRequest();
            }

            _context.Entry(descriptor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DescriptorExists(id))
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

        // DELETE: api/Descriptors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Descriptor>> DeleteDescriptor(long id)
        {
            var descriptor = await _context.Descriptors.FindAsync(id);
            if (descriptor == null)
            {
                return NotFound();
            }

            _context.Descriptors.Remove(descriptor);
            await _context.SaveChangesAsync();

            return descriptor;
        }

        private bool DescriptorExists(long id)
        {
            return _context.Descriptors.Any(e => e.Id == id);
        }
    }
}
