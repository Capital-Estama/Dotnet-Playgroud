using System.ComponentModel.DataAnnotations;
namespace ChefsAndDishes.Models;

public class Chef
{
    [Key]
    public int ChefID { get; set; }

    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    // Navigation property for related Message objects.
    public List<Dish> Dishes { get; set; } = new List<Dish>();

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;


}

