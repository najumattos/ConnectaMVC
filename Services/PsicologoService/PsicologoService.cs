using AutoMapper;
using ConnectaMVC.Data;
using ConnectaMVC.Domain;
using ConnectaMVC.Models;
using ConnectaMVC.Models.FormModels;
using ConnectaMVC.Models.ViewModels;
using ConnectaMVC.Services.AuthService;
using ConnectaMVC.Services.UsuarioService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConnectaMVC.Services.PsicologoService;

public class PsicologoService(
     UserManager<UsuarioModel> userManager,
        AppDbContext context,
    IAuthService authService,
    IUsuarioService usuarioService,
     IMapper mapper) : IPsicologoService
{
    public async Task<Result<PsicologoDto>> CriarUsuarioPsicologo(RegisterPsicologoUsuarioDto psicologoUserDto)
    {
        //separa o que é registro do usuario 
        var registerDto = mapper.Map<RegisterDto>(psicologoUserDto);
        var resultRegister = await authService.RegisterAsync(registerDto);

        if (!resultRegister.IsSuccess)
        {
            return Result<PsicologoDto>.Failure(resultRegister.Error);
        }                    //ta errado

        var user = resultRegister.Value; //tirar do envelope
        var userDto = mapper.Map<UserDto>(user);
        var psicologoModel = mapper.Map<PsicologoModel>(psicologoUserDto, opt => opt.Items["UserId"] = user.Id);
        var authDto = AutenticarUsuario(userDto, psicologoModel.TipoPerfil.ToString());
        await userManager.AddToRoleAsync(user, psicologoModel.TipoPerfil.ToString());
        return Result<PsicologoDto>.Success(authDto);
    }   

    /// <summary>
    /// Autenticar usuario cookie
    /// </summary>
   
    private PsicologoDto AutenticarUsuario(UserDto userDto, string tipoPerfil)
    {
      //  var token = jwtService.GenerateToken(userDto);
        var authDto = mapper.Map<PsicologoDto>(userDto);
     //   authDto.Token = token;
      //  authDto.TipoPerfil = tipoPerfil;
        return authDto;
    }
   
    #region Não Implementado

    public Task<Result> AtualizarPsicologo(string idpsicologo, PsicologoDto psicologoDto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<PsicologoDto>> BuscarPsicologoPorId(string idPsicologo)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<PsicologoDto>>> BuscarPsicologoPorNomeOuCRP(string nomeOuCRP)
    {
        throw new NotImplementedException();
    }

    public Task<Result<IEnumerable<FichaUsuarioDto>>> BuscarTodosPsicologos()
    {
        throw new NotImplementedException();
    }
    public Task<Result> DesativarPerfilPsicologo(string idPsicologo)
    {
        throw new NotImplementedException();
    }
    #endregion
}

