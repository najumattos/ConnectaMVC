using ConnectaMVC.Domain;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Services.PacienteService;

public interface IPacienteService
{
    Task<Result<IEnumerable<FichaUsuarioDto>>> BuscarTodosPacientes();
    Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente);
    Task<Result> AtualizarPaciente(string idPaciente, PacienteDto pacienteDto);
    Task<Result> ArquivarPaciente(string idPaciente);
    Task<Result> CriarPaciente(PacienteDto pacienteDto);
    //Task<IEnumerable<ProntuarioDto>> BuscarProntuarioPorPaciente(string idPaciente);

}
