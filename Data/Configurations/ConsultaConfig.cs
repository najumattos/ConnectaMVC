using ConnectaMVC.Helpers;
using ConnectaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectaMVC.Data.Configurations;

public class ConsultaConfig : IEntityTypeConfiguration<ConsultaModel>
{
    public void Configure(EntityTypeBuilder<ConsultaModel> builder)
    {
        builder.HasOne(c => c.Prontuario)
         .WithMany(p => p.ConsultasVinculadas)
         .HasForeignKey(c => c.ProntuarioId)
         .OnDelete(DeleteBehavior.Restrict); // Segurança: não apaga consultas se o prontuário sumir

        builder.HasData(
            new ConsultaModel
            {
                ConsultaId = SeedDataConstants.CONSULTA_ID,
                AnotacoesConsulta = "Resumo sessao resumida",
                DataHoraConsulta = new DateTime(2002, 4, 1),
                DuracaoConsulta = TimeSpan.FromMinutes(50),
                ProntuarioId = SeedDataConstants.PRONTUARIO_ID,
                PsicologoId = SeedDataConstants.ESTUDANTE_ANA_ID
            }
            );
    }
}
