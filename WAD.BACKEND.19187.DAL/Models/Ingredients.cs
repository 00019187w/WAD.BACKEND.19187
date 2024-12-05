using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._19187.Models
{
    public class Ingredients
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Ingredient Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public double Quantity { get; set; }

        [Required(ErrorMessage = "Recipe ID is required")]
        public int RecipeId { get; set; }

        public Recipe? Recipe { get; set; } 
    }
}
