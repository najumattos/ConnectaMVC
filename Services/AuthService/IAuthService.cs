using ConnectaMVC.Domain;
using ConnectaMVC.Models;
using ConnectaMVC.Models.FormModels;
using ConnectaMVC.Models.ViewModels;

namespace ConnectaMVC.Services.AuthService;

public interface IAuthService
{
    Task<Result<UsuarioModel>> RegisterAsync(RegisterDto registerDto);
   // Task<Result<AuthResponseDto>> LoginAsync(LoginDto loginDto);
    Task<Result<UserDto>> GetUserByIdAsync(string userId);
}
