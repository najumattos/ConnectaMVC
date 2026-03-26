using ConnectaMVC.Enums;

namespace ConnectaMVC.Models.ViewModels;

public class ProntuarioDto
{
    public string ProntuarioId { get; set; }
    public string NomePsicologo { get; set; }
    public string NomePaciente { get; set; }
    public TipoProntuarioEnum TipoProntuario { get; set; }
    public DateTime UltimaAtualizacao { get; set; }
    public DateTime DataCriacao { get; set; }
}
