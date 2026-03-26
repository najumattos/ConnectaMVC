using ConnectaMVC.Domain;
using ConnectaMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ConnectaMVC.Services.PacienteService;

public class PacienteService() : IPacienteService
{
    #region Não implementado
    public Task<Result> ArquivarPaciente(string idPaciente)
    {
        throw new NotImplementedException();
    }

    public Task<Result> AtualizarPaciente(string idPaciente, PacienteDto pacienteDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<PacienteDto>> BuscarPacientePorId(string idPaciente)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<FichaUsuarioDto>>> BuscarTodosPacientes()
    {
        throw new NotImplementedException();
    }

    public Task<Result> CriarPaciente(PacienteDto pacienteDto)
    {
        throw new NotImplementedException();
    }
    #endregion
}
