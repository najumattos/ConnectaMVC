using System.ComponentModel.DataAnnotations;

namespace ConnectaMVC.Models.ViewModels;

public class PacienteDto
{
    public string IdPaciente { get; set; }
    public string ContatoEmergencia { get; set; }
    public string HistoricoPaciente { get; set; }
}
