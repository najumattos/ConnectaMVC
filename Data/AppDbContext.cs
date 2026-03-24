using ConnectaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectaMVC.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Tarefa> Tarefas { get; set; }
    public DbSet<ConnectaMVC.Models.UsuarioModel> UsuarioModel { get; set; } = default!;
    public DbSet<ConnectaMVC.Models.PsicologoModel> PsicologoModel { get; set; } = default!;
    public DbSet<ConnectaMVC.Models.PacienteModel> PacienteModel { get; set; } = default!;
    public DbSet<ConnectaMVC.Models.ProntuarioModel> ProntuarioModel { get; set; } = default!;
    public DbSet<ConnectaMVC.Models.ConsultaModel> ConsultaModel { get; set; } = default!;
}