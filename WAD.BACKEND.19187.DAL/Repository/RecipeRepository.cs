using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19187.DATA;
using WAD.BACKEND._19187.Models;

namespace WAD.BACKEND._19187.Repository
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly RecipeBookDBContext _context;

        public RecipeRepository(RecipeBookDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes.ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes.FindAsync(id);
        }

        public async Task<Recipe> AddRecipeAsync(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe)
        {
            if (id != recipe.Id)
                return null;

            _context.Entry(recipe).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
                return false;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RecipeExistsAsync(int id)
        {
            return await _context.Recipes.AnyAsync(e => e.Id == id);
        }
    }
}
