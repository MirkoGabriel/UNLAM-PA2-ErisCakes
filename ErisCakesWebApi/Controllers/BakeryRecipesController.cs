using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ErisCakesWebApi.Data;
using ErisCakesWebApi.Models;
using AutoMapper;
using ErisCakesWebApi.Dto;
using ErisCakesWebApi.Interfaces;

namespace ErisCakesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BakeryRecipesController : ControllerBase
    {
        private readonly IBakeryRecipesRepository _bakeryRecipesRepository;
        private readonly IMapper _mapper;

        public BakeryRecipesController(IBakeryRecipesRepository bakeryRecipesRepository, IMapper mapper)
        {
            _bakeryRecipesRepository = bakeryRecipesRepository;
            _mapper = mapper;
        }

        // GET: api/BakeryRecipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BakeryRecipe>>> GetBakeryRecipes()
        {
            return Ok(_mapper.Map<List<BakeryRecipeDTO>>(_bakeryRecipesRepository.GetBakeryRecipes()));
        }

        // GET: api/BakeryRecipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BakeryRecipe>> GetBakeryRecipe(int id)
        {
            var bakeryRecipe = _mapper.Map<BakeryRecipeDTO>(_bakeryRecipesRepository.GetBakeryRecipe(id));

            if (bakeryRecipe == null)
            {
                return NotFound();
            }

            return Ok(bakeryRecipe);
        }

        // PUT: api/BakeryRecipes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutBakeryRecipe(BakeryRecipe bakeryRecipe)
        {
            return Ok(_bakeryRecipesRepository.EditBakeryRecipe(bakeryRecipe));
        }

        // POST: api/BakeryRecipes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BakeryRecipe>> PostBakeryRecipe(BakeryRecipe bakeryRecipe)
        {
          if(bakeryRecipe.Price < 0)
          {
              throw new ArgumentException("Recipe price must be gratter than 0");
          }
            _bakeryRecipesRepository.CreateBakeryRecipe(bakeryRecipe);

            return CreatedAtAction("GetBakeryRecipe", new { id = bakeryRecipe.Id }, bakeryRecipe);
        }

        // DELETE: api/BakeryRecipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBakeryRecipe(int id)
        {
            _bakeryRecipesRepository.DeleteBakeryRecipe(id);
            return NoContent();
        }

        
    }
}
