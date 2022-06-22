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
    [Route("api/GeocachingItems")]
    [ApiController]
    public class GeocachingItemsController : ControllerBase
    {
        private readonly GeocachingContext _context;

        public GeocachingItemsController(GeocachingContext context)
        {
            _context = context;
        }

        // GET: api/GeocachingItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeocachingItems>>> GetGeocachingItem()
        {
          if (_context.GeocachingItem == null)
          {
              return NotFound();
          }
            return await _context.GeocachingItem.ToListAsync();
        }

        // GET: api/GeocachingItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeocachingItems>> GetGeocachingItems(long id)
        {
          if (_context.GeocachingItem == null)
          {
              return NotFound();
          }
            var geocachingItems = await _context.GeocachingItem.FindAsync(id);

            if (geocachingItems == null)
            {
                return NotFound();
            }

            return geocachingItems;
        }

        // PUT: api/GeocachingItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeocachingItems(long id, GeocachingItems geocachingItems)
        {
            if (id != geocachingItems.Id)
            {
                return BadRequest();
            }

            if (geocachingItems.ItemName.Length > 50)
            {
                return BadRequest();
            }

            _context.Entry(geocachingItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeocachingItemsExists(id))
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

        // POST: api/GeocachingItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeocachingItems>> PostGeocachingItems(GeocachingItems geocachingItems)
        {
          //if (_context.GeocachingItem == null)
          //{
          //    return Problem("Entity set 'GeocachingContext.GeocachingItem'  is null.");
          //}
            _context.GeocachingItem.Add(geocachingItems);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetGeocachingItems", new { id = geocachingItems.Id }, geocachingItems);
            return CreatedAtAction(nameof(GetGeocachingItems), new {id = geocachingItems.Id}, geocachingItems);
        }

        // DELETE: api/GeocachingItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeocachingItems(long id)
        {
            if (_context.GeocachingItem == null)
            {
                return NotFound();
            }
            var geocachingItems = await _context.GeocachingItem.FindAsync(id);
            if (geocachingItems == null)
            {
                return NotFound();
            }

            _context.GeocachingItem.Remove(geocachingItems);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeocachingItemsExists(long id)
        {
            return (_context.GeocachingItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
