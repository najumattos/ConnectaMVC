using ConnectaMVC.Helpers;
using ConnectaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectaMVC.Data.Configurations;

public class PacienteConfig : IEntityTypeConfiguration<PacienteModel>
{
    public void Configure(EntityTypeBuilder<PacienteModel> builder)
    {
        // 1. Define que o UsuarioId é a Chave Primária
        builder.HasKey(p => p.PacienteId);

        // 2. Configura o relacionamento 1:1 com o Usuario
        builder.HasOne(p => p.Usuario)
               .WithOne()
               .HasForeignKey<PacienteModel>(p => p.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(new PacienteModel
        {
            PacienteId = SeedDataConstants.PACIENTE_GALLO_ID,
            UsuarioId = SeedDataConstants.USER_GALLO_ID,
            ContatoEmergencia = "14999009858",
            HistoricoPaciente = "Histórico inicial do paciente."
        });
    }
}
