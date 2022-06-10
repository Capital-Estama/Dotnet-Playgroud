using System.ComponentModel.DataAnnotations;
namespace DojoSurvey.Models;
#pragma warning disable CS8618

public class User
{
    [Required()]
    [MinLength(2, ErrorMessage =" Min Length 2")]
    public string Name {get; set;}
    [Required]
    public string Location {get; set;}
    [Required]
    public string Lang {get; set;}
    public string? Comments {get; set;}

}