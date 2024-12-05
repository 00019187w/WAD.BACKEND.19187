using WAD.BACKEND._19187.Models;

namespace WAD.BACKEND._19187.Repository
{
    public interface IIngredientRepository
    {
        Task<IEnumerable<Ingredients>> GetAllIngredientsAsync();
        Task<Ingredients> GetIngredientByIdAsync(int id);
        Task<Ingredients> AddIngredientAsync(Ingredients ingredient);
        Task<Ingredients> UpdateIngredientAsync(int id, Ingredients ingredient);
        Task<bool> DeleteIngredientAsync(int id);
        Task<bool> IngredientExistsAsync(int id);
    }
}
