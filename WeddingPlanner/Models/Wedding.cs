using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class Wedding
{
    [Key]
    public int WeddingID { get; set; }
    // keep Track of who created Wedding
    [Required]
    public int OwnerID { get; set; }
    [Required]
    public string WedderOne { get; set; }

    [Required]
    public string WedderTwo { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Address { get; set; }

    
    public List<Association> Guests { get; set; } = new List<Association>();


    public DateTime CreatedAT { get; set; } = DateTime.Now;
    public DateTime UpdatedAT { get; set; } = DateTime.Now;

}