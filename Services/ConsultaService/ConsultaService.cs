using ConnectaMVC.Domain;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Services.ConsultaService;

public class ConsultaService : IConsultaService
{
    #region Não Implementado
    public Task<Result> AgendarConsulta(ConsultaDto consultaDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<ConsultaDto>> BuscarConsultaPorId(string idConsulta)
    {
        throw new NotImplementedException();
    }

    public Task<ConsultaDto> BuscarConsultaPorProntuario(string idProntuario)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<ConsultaDto>>> BuscarTodasConsultas()
    {
        throw new NotImplementedException();
    }

    public Task<Result> DeletarConsulta(string idConsulta)
    {
        throw new NotImplementedException();
    }

    public Task<Result<bool>> EditarInfosConsulta(string idProntuario, ConsultaDto consultaDto)
    {
        throw new NotImplementedException();
    }
    #endregion
}
