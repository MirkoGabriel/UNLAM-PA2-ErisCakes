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
    public class BakeryRecipesController : ControllerBase
    {
        private readonly DataContext _context;

        public BakeryRecipesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/BakeryRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakeryRecipe>>> GetBakeryRecipes()
        {
          if (_context.BakeryRecipes == null)
          {
              return NotFound();
          }
            return await _context.BakeryRecipes.ToListAsync();
        }

        // GET: api/BakeryRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BakeryRecipe>> GetBakeryRecipe(int id)
        {
          if (_context.BakeryRecipes == null)
          {
              return NotFound();
          }
            var bakeryRecipe = await _context.BakeryRecipes.FindAsync(id);

            if (bakeryRecipe == null)
            {
                return NotFound();
            }

            return bakeryRecipe;
        }

        // PUT: api/BakeryRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBakeryRecipe(int id, BakeryRecipe bakeryRecipe)
        {
            if (id != bakeryRecipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(bakeryRecipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BakeryRecipeExists(id))
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

        // POST: api/BakeryRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BakeryRecipe>> PostBakeryRecipe(BakeryRecipe bakeryRecipe)
        {
          if (_context.BakeryRecipes == null)
          {
              return Problem("Entity set 'DataContext.BakeryRecipes'  is null.");
          }
            _context.BakeryRecipes.Add(bakeryRecipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBakeryRecipe", new { id = bakeryRecipe.Id }, bakeryRecipe);
        }

        // DELETE: api/BakeryRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBakeryRecipe(int id)
        {
            if (_context.BakeryRecipes == null)
            {
                return NotFound();
            }
            var bakeryRecipe = await _context.BakeryRecipes.FindAsync(id);
            if (bakeryRecipe == null)
            {
                return NotFound();
            }

            _context.BakeryRecipes.Remove(bakeryRecipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BakeryRecipeExists(int id)
        {
            return (_context.BakeryRecipes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
