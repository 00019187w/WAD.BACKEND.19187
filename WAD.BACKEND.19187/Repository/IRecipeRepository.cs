using WAD.BACKEND._19187.Models;

namespace WAD.BACKEND._19187.Repository
{
    public interface IRecipeRepository
    {
        Task<IEnumerable<Recipe>> GetAllRecipesAsync();
        Task<Recipe> GetRecipeByIdAsync(int id);
        Task<Recipe> AddRecipeAsync(Recipe recipe);
        Task<Recipe> UpdateRecipeAsync(int id, Recipe recipe);
        Task<bool> DeleteRecipeAsync(int id);
        Task<bool> RecipeExistsAsync(int id);
    }
}
