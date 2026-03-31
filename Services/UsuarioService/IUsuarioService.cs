using ConnectaMVC.Domain;
using ConnectaMVC.Models;
using ConnectaMVC.Models.FormModels;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Services.UsuarioService;

public interface IUsuarioService
{
    Task<Result<IEnumerable<FichaUsuarioDto>>> BuscarTodosUsuarios();
    Task<Result<UserDto>> BuscarUsuarioPorId(string idUsuario);
    Task<Result> AtualizarUsuario(string idUsuario, IFormFile arquivoFoto, UserUpdateDto usuarioUpdateDto);
    Task<Result> DesativarCadastro(string idUsuario);
    UserDto MapearUserDto(UsuarioModel usuario);
    Task<Result> RegistrarUsuario(RegisterDto registerDto);
}
