using System.ComponentModel.DataAnnotations;

namespace ConnectaMVC.Models.FormModels;

public class LoginDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Senha { get; set; }
}
