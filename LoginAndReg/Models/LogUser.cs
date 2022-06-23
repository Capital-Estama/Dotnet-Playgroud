using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace LoginAndReg.Models;

public class LogUser
{
   
    [EmailAddress]
    [Required]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [MinLength(8)]
    [Required]
    public string Password { get; set; }



}


