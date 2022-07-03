using System.ComponentModel.DataAnnotations;
namespace WeddingPlanner.Models;

public class LogUser
{
    [Required]
    [DataType(DataType.EmailAddress)]
    public string LogEmail { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string LogPassword { get; set; }
}

