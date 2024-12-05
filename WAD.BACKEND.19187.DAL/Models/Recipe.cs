using System.ComponentModel.DataAnnotations;

namespace WAD.BACKEND._19187.Models
{
    public class Recipe
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "Recipe Name is required")]
        [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } 

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } 

        [Required(ErrorMessage = "Preparation Time is required")]
        [Range(1, 1000, ErrorMessage = "Preparation time must be between 1 and 1000 minutes")]
        public int PreparationTime { get; set; } 

        [Required(ErrorMessage = "Servings are required")]
        [Range(1, 100, ErrorMessage = "Servings must be between 1 and 100")]
        public int Servings { get; set; } 

    }
}
