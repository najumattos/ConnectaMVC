using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConnectaMVC.Models;

[Table("Consulta")]
public class ConsultaModel
{
    [Key]
    public string ConsultaId { get; set; } = Guid.NewGuid().ToString();

    [Required] public DateTime DataHoraConsulta { get; set; }

    [Required] public TimeSpan DuracaoConsulta { get; set; }

    [StringLength(1000), Required(ErrorMessage = "Campo obrigatório")]
    public string AnotacoesConsulta { get; set; }


     public string PsicologoId { get; set; }
     [ForeignKey(nameof(PsicologoId))]
     public virtual PsicologoModel Psicologo { get; set; }

    public string ProntuarioId { get; set; }
    [ForeignKey(nameof(ProntuarioId))]
    public virtual ProntuarioModel Prontuario { get; set; }

    public DateOnly DataCadastro { get; set; }
}
