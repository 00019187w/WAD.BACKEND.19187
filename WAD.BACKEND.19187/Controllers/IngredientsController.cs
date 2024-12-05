using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19187.DATA;
using WAD.BACKEND._19187.Models;

namespace WAD.BACKEND._19187.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly RecipeBookDBContext _context;

        public IngredientsController(RecipeBookDBContext context)
        {
            _context = context;
        }

        // GET: api/Ingredients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingredients>>> GetIngredients()
        {
            return await _context.Ingredients.ToListAsync();
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredients>> GetIngredient(int id)
        {
            var ingredient = await _context.Ingredients
                                           .Include(i => i.Recipe)
                                           .FirstOrDefaultAsync(i => i.Id == id);

            if (ingredient == null)
            {
                return NotFound(new { message = "Ingredient not found." });
            }

            return ingredient;
        }


        // POST: api/Ingredients
        [HttpPost]
        public async Task<ActionResult<Ingredients>> PostIngredient(Ingredients ingredient)
        {
            // Validate RecipeId
            var recipe = await _context.Recipes.FindAsync(ingredient.RecipeId);
            if (recipe == null)
            {
                return BadRequest(new { message = "Invalid RecipeId. Recipe does not exist." });
            }

            // Add the ingredient
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetIngredient), new { id = ingredient.Id }, ingredient);
        }

        // PUT: api/Ingredients/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngredient(int id, Ingredients ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest(new { message = "Ingredient ID mismatch." });
            }

            // Validate RecipeId
            var recipe = await _context.Recipes.FindAsync(ingredient.RecipeId);
            if (recipe == null)
            {
                return BadRequest(new { message = "Invalid RecipeId. Recipe does not exist." });
            }

            _context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredientExists(id))
                {
                    return NotFound(new { message = "Ingredient not found." });
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return NotFound(new { message = "Ingredient not found." });
            }

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredientExists(int id)
        {
            return _context.Ingredients.Any(e => e.Id == id);
        }
    }
}
