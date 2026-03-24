using ConnectaMVC.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaMVC.Models;

[Table("Usuario")]
public class UsuarioModel : IdentityUser
{

    [Display(Name = "Nome do Usuário", Prompt = "Informe o nome"),
    Required(ErrorMessage = "Informe o nome do Usuario"),
    StringLength(150)]
    public string Nome { get; set; }

    [Display(Name = "Sobrenome do Usuário", Prompt = "Informe o sobrenome"),
    Required(ErrorMessage = "Informe o Sobrenome do Usuario"),
    StringLength(150)]
    public string Sobrenome { get; set; }

    [Display(Name = "Data De Nascimento", Prompt = "Informe a Data De Nascimento"),
    Required(ErrorMessage = "Informe a Data De Nascimento")]
    public DateOnly DataNascimento { get; set; }

    [Display(Prompt = "Escolha uma Foto"), StringLength(300)]
    public string Foto { get; set; }
    public TipoModuloEnum TipoModulo { get; set; }


    [NotMapped] // Isso avisa ao Entity Framework para não criar uma coluna no banco para isso
    public string NomeCompleto => $"{Nome} {Sobrenome}";
}
