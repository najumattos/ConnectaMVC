using ConnectaMVC.Data.Configurations;
using ConnectaMVC.Helpers;
using ConnectaMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConnectaMVC.Data;
public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<UsuarioModel>(options)
{
    public DbSet<UsuarioModel> UsuarioModel { get; set; }
    public DbSet<PsicologoModel> PsicologoModel { get; set; }
    public DbSet<PacienteModel> PacienteModel { get; set; }
    public DbSet<ProntuarioModel> ProntuarioModel { get; set; }
    public DbSet<ConsultaModel> ConsultaModel { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        PopulateRoles(builder);
        builder.ApplyConfiguration(new UserConfig());
        builder.ApplyConfiguration(new ProntuarioConfig());
        builder.ApplyConfiguration(new PacienteConfig());
        builder.ApplyConfiguration(new ConsultaConfig());
        builder.ApplyConfiguration(new PsicologoConfig());
    }
    private static void PopulateRoles(ModelBuilder builder)
    {
        List<IdentityRole> roles =
        [
            new IdentityRole() {
               Id = SeedDataConstants.USER_ANA_ID,
               Name = "Estudante",
               NormalizedName = "ESTUDANTE"
            },
                       new IdentityRole() {
               Id = SeedDataConstants.USER_TAINARA_ID,
               Name = "Coordendor",
               NormalizedName = "COORDENADOR"
            },
            new IdentityRole() {
               Id = SeedDataConstants.PACIENTE_GALLO_ID,
               Name = "Clinica",
               NormalizedName = "CLINICA"
            },
        ];
        builder.Entity<IdentityRole>().HasData(roles);

        #region Populate UserRole - Usuário com Perfil
        List<IdentityUserRole<string>> userRoles =
        [
            new IdentityUserRole<string>() {
                UserId =SeedDataConstants.USER_ANA_ID,
                RoleId = roles[0].Id
            },
            new IdentityUserRole<string>() {
                UserId = SeedDataConstants.USER_TAINARA_ID,
                RoleId = roles[1].Id
            },
            new IdentityUserRole<string>() {
                UserId = SeedDataConstants.USER_GALLO_ID,
                RoleId = roles[2].Id
            }
        ];
        builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        #endregion
    }
}