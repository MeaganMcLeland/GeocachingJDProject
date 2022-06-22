using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GeocachingJDProject.Models;

namespace GeocachingJDProject.Controllers
{
    [Route("api/GeocachingContainers")]
    [ApiController]
    public class GeocachingContainersController : ControllerBase
    {
        private readonly GeocachingContext _context;

        public GeocachingContainersController(GeocachingContext context)
        {
            _context = context;
        }

        // GET: api/GeocachingContainers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeocachingContainers>>> GetGeocachingContainer()
        {
          if (_context.GeocachingContainer == null)
          {
              return NotFound();
          }
            return await _context.GeocachingContainer.ToListAsync();
        }

        // GET: api/GeocachingContainers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeocachingContainers>> GetGeocachingContainers(long id)
        {
          if (_context.GeocachingContainer == null)
          {
              return NotFound();
          }
            var geocachingContainers = await _context.GeocachingContainer.FindAsync(id);

            if (geocachingContainers == null)
            {
                return NotFound();
            }

            return geocachingContainers;
        }

        // PUT: api/GeocachingContainers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeocachingContainers(long id, GeocachingContainers geocachingContainers)
        {
            if (id != geocachingContainers.Id)
            {
                return BadRequest();
            }

            if(geocachingContainers.Longitude > 180 || geocachingContainers.Longitude < -180)
            {
                return BadRequest();
            }

            if(geocachingContainers.Latitude > 90 || geocachingContainers.Latitude < -90)
            {
                return BadRequest();
            }
            _context.Entry(geocachingContainers).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeocachingContainersExists(id))
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

        // POST: api/GeocachingContainers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeocachingContainers>> PostGeocachingContainers(GeocachingContainers geocachingContainers)
        {
          //if (_context.GeocachingContainer == null)
          //{
          //    return Problem("Entity set 'GeocachingContext.GeocachingContainer'  is null.");
          //}
            _context.GeocachingContainer.Add(geocachingContainers);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGeocachingContainers", new { id = geocachingContainers.Id }, geocachingContainers);
            return CreatedAtAction(nameof(GetGeocachingContainers), new {id = geocachingContainers.Id}, geocachingContainers);
        }

        // DELETE: api/GeocachingContainers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeocachingContainers(long id)
        {
            if (_context.GeocachingContainer == null)
            {
                return NotFound();
            }
            var geocachingContainers = await _context.GeocachingContainer.FindAsync(id);
            if (geocachingContainers == null)
            {
                return NotFound();
            }

            _context.GeocachingContainer.Remove(geocachingContainers);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeocachingContainersExists(long id)
        {
            return (_context.GeocachingContainer?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
