using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;

public class Dish
{
    [Key]
    public int DishID { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Calories { get; set; }

    [Required]
    [Range(1, 5)]
    public int Tastiness { get; set; }

    [Required]
    public string? Description { get; set; }

    [Required] 
    public int ChefID { get; set; }

    // Navigation property for related User object
    public Chef? Chef { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}


