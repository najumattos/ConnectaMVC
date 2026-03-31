using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ConnectaMVC.Data;
using ConnectaMVC.Models;
using ConnectaMVC.Models.ViewModels;
using ConnectaMVC.Services.UsuarioService;
using ConnectaMVC.Domain;
using ConnectaMVC.Models.FormModels;

namespace ConnectaMVC.Controllers;

public class UsuariosController(IUsuarioService service) : Controller
{

    /// <summary>
    /// Busca Todos Usuarios
    /// </summary>
   public async Task<ActionResult> Index()
    {
        var result = await service.BuscarTodosUsuarios();
        if(!result.IsSuccess)
        {
            ViewBag.ErrorMessage = result.Error;
            return View(Enumerable.Empty<FichaUsuarioDto>());
        }
        return View(result.Value);
    }

    /// <summary>
    /// Exibe Dados Cadastrais do Usuario
    /// </summary> 
    public async Task<IActionResult> Details(string id)
    {
        var result = await service.BuscarUsuarioPorId(id);
        return result switch
        {
            { IsSuccess: true } => View(result.Value), // Sucesso: Vai para a View de detalhes
            { IsSuccess: false } => View(result.Error), // Falha: Retorna 404 com a mensagem
            null => StatusCode(500, "Erro inesperado no servidor, serve a dor") // Caso o serviço falhe gravemente          
        };

    }

    /// <summary>
    /// Atualiza Cadastro do Usuario
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, IFormFile foto, [FromForm] UserUpdateDto usuarioUpdateDto)
    {
        var result = await service.AtualizarUsuario(id, foto, usuarioUpdateDto);
        return result switch
        {
            // Sucesso: Redireciona para não reenviar o form ao dar F5
            { IsSuccess: true } => RedirectToAction(nameof(Index)),

            // Falha: Volta para a View de edição mostrando o erro e mantendo os dados digitados
            { IsSuccess: false } => View("Edit", usuarioUpdateDto),

            null => StatusCode(500, "Erro inesperado no servidor")
        };


    }

    /// <summary>
    /// Desativa?? Cadastro do Usuario
    /// </summary>
    [HttpPatch("{id}")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Desativar(string id)
    {
        var result = await service.DesativarCadastro(id);
        return result switch
        {
            { IsSuccess: true } => RedirectToAction(nameof(Index)), // Sucesso: Vai para a View de detalhes
            { IsSuccess: false } => View("Details", result.Error), // Falha: Retorna 404 com a mensagem
            _ => StatusCode(500, "Erro inesperado no servidor, serve a dor") // Caso o serviço falhe gravemente          
        };
    }

    /// <summary>
    /// Criar Cadastro do Usuario
    /// </summary>
    [HttpPost]
    [ValidateAntiForgeryToken]     //essencial para proteger contra ataques CSRF em aplicações MVC
    public async Task<IActionResult> Create(RegisterDto registerDto)
    {
        var result = await service.RegistrarUsuario(registerDto);
        return result switch
        {
            // Sucesso: Redireciona para não reenviar o form ao dar F5
            { IsSuccess: true } => RedirectToAction(nameof(Index)),

            // Falha: Volta para a View Home mostrando o erro e mantendo os dados digitados
            { IsSuccess: false } => View("Home", registerDto),

            null => StatusCode(500, "Erro inesperado no servidor")
        };


    }
}
