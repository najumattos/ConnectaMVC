using ConnectaMVC.Domain;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Services.ProntuarioService;

public class ProntuarioService : IProntuarioService
{
    #region Não Implementado
    public Task<Result> ArquivarProntuario(string idProntuario)
    {
        throw new NotImplementedException();
    }

    public Task<Result> AtualizarProntuario(string idProntuario, ProntuarioDto ProntuarioDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ProntuarioDto>> BuscarProntuarioPorId(string idProntuario)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<ProntuarioBasicoDto>>> BuscarTodosProntuarios()
    {
        throw new NotImplementedException();
    }

    public Task<Result> CriarProntuario(ProntuarioDto ProntuarioDto)
    {
        throw new NotImplementedException();
    }
    #endregion
}
