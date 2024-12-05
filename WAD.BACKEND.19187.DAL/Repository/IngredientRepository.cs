using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19187.DATA;
using WAD.BACKEND._19187.Models;

namespace WAD.BACKEND._19187.Repository
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeBookDBContext _context;

        public IngredientRepository(RecipeBookDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ingredients>> GetAllIngredientsAsync()
        {
            return await _context.Ingredients.ToListAsync();
        }

        public async Task<Ingredients> GetIngredientByIdAsync(int id)
        {
            return await _context.Ingredients.FindAsync(id);
        }

        public async Task<Ingredients> AddIngredientAsync(Ingredients ingredient)
        {
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<Ingredients> UpdateIngredientAsync(int id, Ingredients ingredient)
        {
            if (id != ingredient.Id)
                return null;

            _context.Entry(ingredient).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return ingredient;
        }

        public async Task<bool> DeleteIngredientAsync(int id)
        {
            var ingredient = await _context.Ingredients.FindAsync(id);
            if (ingredient == null)
                return false;

            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IngredientExistsAsync(int id)
        {
            return await _context.Ingredients.AnyAsync(e => e.Id == id);
        }
    }
}
