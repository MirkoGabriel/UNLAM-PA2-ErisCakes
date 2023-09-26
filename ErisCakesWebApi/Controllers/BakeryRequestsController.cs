using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErisCakesWebApi.Data;
using ErisCakesWebApi.Models;

namespace ErisCakesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryRequestsController : ControllerBase
    {
        private readonly DataContext _context;

        public BakeryRequestsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BakeryRequests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakeryRequest>>> GetBakeryRequests()
        {
          if (_context.BakeryRequests == null)
          {
              return NotFound();
          }
            return await _context.BakeryRequests
                .AsNoTracking()
                .Include(br => br.Client)
                .Include(br => br.BakeryRequestRecipes).ThenInclude(brr => brr.BakeryRecipe)
                .ToListAsync();
        }

        // GET: api/BakeryRequests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BakeryRequest>> GetBakeryRequest(int id)
        {
          if (_context.BakeryRequests == null)
          {
              return NotFound();
          }
            var bakeryRequest = await _context.BakeryRequests
                .AsNoTracking()
                .Include(br => br.Client)
                .Include(br => br.BakeryRequestRecipes).ThenInclude(brr => brr.BakeryRecipe)
                .SingleOrDefaultAsync(br => br.Id == id);

            if (bakeryRequest == null)
            {
                return NotFound();
            }

            return bakeryRequest;
        }

        // PUT: api/BakeryRequests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBakeryRequest(int id, BakeryRequest bakeryRequest)
        {
            if (id != bakeryRequest.Id)
            {
                return BadRequest();
            }

            _context.Entry(bakeryRequest).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BakeryRequestExists(id))
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

        // POST: api/BakeryRequests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BakeryRequest>> PostBakeryRequest(BakeryRequest bakeryRequest)
        {
          if (_context.BakeryRequests == null)
          {
              return Problem("Entity set 'DataContext.BakeryRequests'  is null.");
          }
            _context.BakeryRequests.Add(bakeryRequest);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBakeryRequest", new { id = bakeryRequest.Id }, bakeryRequest);
        }

        // DELETE: api/BakeryRequests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBakeryRequest(int id)
        {
            if (_context.BakeryRequests == null)
            {
                return NotFound();
            }
            var bakeryRequest = await _context.BakeryRequests.FindAsync(id);
            if (bakeryRequest == null)
            {
                return NotFound();
            }

            _context.BakeryRequests.Remove(bakeryRequest);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BakeryRequestExists(int id)
        {
            return (_context.BakeryRequests?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
