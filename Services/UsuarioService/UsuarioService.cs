using ConnectaMVC.Domain;
using ConnectaMVC.Models;
using ConnectaMVC.Models.FormModels;
using ConnectaMVC.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ConnectaMVC.Services.UsuarioService;

public class UsuarioService() : IUsuarioService
{
    #region Não Implementado
    public Task<Result> AtualizarUsuario(string idUsuario, IFormFile arquivoFoto, UserUpdateDto usuarioUpdateDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<FichaUsuarioDto>>> BuscarTodosUsuarios()
    {
        throw new NotImplementedException();
    }

    public Task<Result<UserDto>> BuscarUsuarioPorId(string idUsuario)
    {
        throw new NotImplementedException();
    }

    public Task<Result> DesativarCadastro(string idUsuario)
    {
        throw new NotImplementedException();
    }

    public UserDto MapearUserDto(UsuarioModel usuario)
    {
        throw new NotImplementedException();
    }
    #endregion
}