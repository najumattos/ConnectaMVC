using AutoMapper;
using ConnectaMVC.Models;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Domain;

public class ConfigurationProfile : Profile
{
    public ConfigurationProfile()
    {
        //verificar isso aquiiiiidadnsadbab
        // Mapeamento nos dois sentidos (Entidade <-> DTO)
        CreateMap<ConsultaModel, ConsultaDto>().ReverseMap();
        CreateMap<UsuarioModel, UserDto>().ReverseMap();
        CreateMap<PsicologoModel, PsicologoDto>().ReverseMap();
        CreateMap<PacienteModel, PacienteDto>().ReverseMap();
        CreateMap<ProntuarioModel, ProntuarioDto>().ReverseMap();

    }
}