using Microsoft.EntityFrameworkCore;
using WAD.BACKEND._19187.Models;

namespace WAD.BACKEND._19187.DATA
{
    public class RecipeBookDBContext:DbContext
    {
        public RecipeBookDBContext(DbContextOptions<RecipeBookDBContext> options): base(options){}
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
    }
}
