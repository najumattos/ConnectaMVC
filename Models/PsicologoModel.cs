using ConnectaMVC.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConnectaMVC.Models;

[Table("Psicologo")]
public class PsicologoModel
{
    [Key]
    public string UsuarioId { get; set; }
    [ForeignKey("UsuarioId")]
    public virtual UsuarioModel Usuario { get; set; }

    //nº de registro como psicologo
    [Required(ErrorMessage = "O numero do Registro é obrigatório")]
    public string CRP { get; set; }   // ou RA

    [Display(Name = "Sobre o Psicologo", Prompt = "Descreva você e seu trabalho"),
    StringLength(1000), Required(ErrorMessage = "Campo obrigatório")]
    public string Descricao { get; set; }
    public TipoPerfilEnum TipoPerfil { get; set; }

   // public ICollection<ProntuarioModel> Prontuarios { get; set; }

   // public ICollection<ConsultaModel> ConsultasAgendadas { get; set; }

}
