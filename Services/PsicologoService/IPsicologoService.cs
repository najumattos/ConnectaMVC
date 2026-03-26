using ConnectaMVC.Domain;
using ConnectaMVC.Models.FormModels;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Services.PsicologoService;

public interface IPsicologoService
{
    Task<Result<IEnumerable<FichaUsuarioDto>>> BuscarTodosPsicologos();
    Task<Result<IEnumerable<PsicologoDto>>> BuscarPsicologoPorNomeOuCRP(string nomeOuCRP);
    Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo);
    Task<Result> AtualizarPsicologo(string idpsicologo, PsicologoDto psicologoDto);
    Task<Result> DesativarPerfilPsicologo(string idPsicologo);
    Task<Result<PsicologoDto>> CriarUsuarioPsicologo(RegisterPsicologoUsuarioDto registerPsicologoUsuarioDto);
    //Task<Result<IEnumerable<ProntuarioDto>>> BuscarProntuarioPorPsicologo(string idPsicologo);


}
