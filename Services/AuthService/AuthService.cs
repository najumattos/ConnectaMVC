using AutoMapper;
using ConnectaMVC.Data;
using ConnectaMVC.Domain;
using ConnectaMVC.Helpers;
using ConnectaMVC.Models;
using ConnectaMVC.Models.FormModels;
using ConnectaMVC.Models.ViewModels;
using ConnectaMVC.Services.FileService;
using ConnectaMVC.Services.UsuarioService;
using Microsoft.AspNetCore.Identity;

namespace ConnectaMVC.Services.AuthService;

public class AuthService(
    UserManager<UsuarioModel> userManager,
    SignInManager<UsuarioModel> signInManager,
    IFileService fileService,
    IMapper mapper
    ) : IAuthService
{
    /// <summary>
    /// Mudar para Login cookie 
    /// </summary>
    /// 
    #region metodo de login com token
    /*
    public async Task<Result<AuthResponseDto>> LoginAsync(LoginDto loginDto)
    {
        var user = await VerificarLogin(loginDto);
        var userDto = mapper.Map<UserDto>(user);
       // var token = jwtService.GenerateToken(userDto);
        await context.SaveChangesAsync();
        var authResponseDto = mapper.Map<AuthResponseDto>(userDto);
     //   authResponseDto.Token = token;
        return Result<AuthResponseDto>.Success(authResponseDto);
    }  */
    #endregion


    /// <summary>
    /// Registrar Usuario
    /// </summary>
    public async Task<Result<UsuarioModel>> RegisterAsync(RegisterDto registerDto)
    {

        var existingUser = await userManager.FindByEmailAsync(registerDto.Email);
        if (existingUser != null)
        {
            Result<UserDto>.Failure("Email não encontrado");
        }

        // Salvar a foto se existir
        string fotoPath = null;
        if (registerDto.Foto != null)
        {
            fotoPath = await fileService.SaveFileAsync(registerDto.Foto, "img/usuarios");
        }
        var user = mapper.Map<UsuarioModel>(registerDto);
        user.Foto = fotoPath;
        var result = await userManager.CreateAsync(user, registerDto.Senha);
        if (!result.Succeeded)
        {
            if (fotoPath != null)
                await fileService.DeleteFileAsync(fotoPath);

            var errors = string.Join(", ", result.Errors.Select(e => TranslateIdentityErrors.TranslateErrorMessage(e.Code)));
            Result<UsuarioModel>.Failure($"Falha ao criar usuário: {errors}");
        }



        return Result<UsuarioModel>.Success(user);
    }

    #region OKAY    
    /// <summary>
    /// Buscar Usuario Por Id OKAY
    /// </summary>
    public async Task<Result<UserDto>> GetUserByIdAsync(string userId)
    {
        var user = await userManager.FindByIdAsync(userId);
        if (user == null)
        {
            Result<UserDto>.Failure("Usuario não encontrado");
        }

        var userDto = mapper.Map<UserDto>(user);

        return Result<UserDto>.Success(userDto);
    }

    /// <summary>
    /// Verificar Login OKAY
    /// </summary>
    private async Task<Result<UsuarioModel>> VerificarLogin(LoginDto loginDto)
    {
        var user = await userManager.FindByEmailAsync(loginDto.Email);
        if (user == null) return Result<UsuarioModel>.Failure("Usuario ou senha incorretos");
        var result = await signInManager.CheckPasswordSignInAsync(user, loginDto.Senha, false);
        if (!result.Succeeded) return Result<UsuarioModel>.Failure("Usuario ou senha incorretos");

        return Result<UsuarioModel>.Success(user);
    }     
    #endregion
}