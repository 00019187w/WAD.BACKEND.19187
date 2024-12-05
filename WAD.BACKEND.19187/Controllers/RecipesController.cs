using Microsoft.AspNetCore.Mvc;
using WAD.BACKEND._19187.Models;
using WAD.BACKEND._19187.Repository;

namespace WAD.BACKEND._19187.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly IRecipeRepository _repository;

        public RecipesController(IRecipeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
        {
            return Ok(await _repository.GetAllRecipesAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(int id)
        {
            var recipe = await _repository.GetRecipeByIdAsync(id);
            if (recipe == null)
                return NotFound();

            return Ok(recipe);
        }

        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            var newRecipe = await _repository.AddRecipeAsync(recipe);
            return CreatedAtAction(nameof(GetRecipe), new { id = newRecipe.Id }, newRecipe);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecipe(int id, Recipe recipe)
        {
            var updatedRecipe = await _repository.UpdateRecipeAsync(id, recipe);
            if (updatedRecipe == null)
                return BadRequest();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var success = await _repository.DeleteRecipeAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }
    }
}
