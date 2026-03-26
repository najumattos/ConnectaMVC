using ConnectaMVC.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaMVC.Models;

[Table("Psicologo")]
public class PsicologoModel
{
    [Key]
    public string PsicologoId { get; set; } = Guid.NewGuid().ToString();

    [Required]
    public string UsuarioId { get; set; }
    [ForeignKey(nameof(UsuarioId))]
    public virtual UsuarioModel Usuario { get; set; }

    //nº de registro como psicologo
    [Required(ErrorMessage = "O numero do Registro é obrigatório")]
    public string RegistroAcademico { get; set; }   //CRP ou RA

    [Display(Name = "Sobre o Psicologo", Prompt = "Descreva você e seu trabalho"),
    StringLength(1000), Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; }
    public TipoPerfilEnum TipoPerfil { get; set; }

   public ICollection<ProntuarioModel>? Prontuarios { get; set; }           //para ver consultas agendadas de um psicologo, tem que acessar pelo prontuario

}
