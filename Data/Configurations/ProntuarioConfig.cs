using ConnectaMVC.Helpers;
using ConnectaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectaMVC.Data.Configurations;

public class ProntuarioConfig : IEntityTypeConfiguration<ProntuarioModel>
{
    public void Configure(EntityTypeBuilder<ProntuarioModel> builder)
    {
        // Relacionamento com Psicólogo
        builder.HasOne(p => p.PsicologoResponsavel)
               .WithMany(ps => ps.Prontuarios)
               .HasForeignKey(p => p.PsicologoResponsavelId)
               .OnDelete(DeleteBehavior.Restrict); // Evita deletar o psicólogo e apagar tudo por acidente

        // Relacionamento 1:1 com Paciente
        builder.HasOne(p => p.Paciente)
               .WithOne(pac => pac.Prontuario) // Aqui dizemos que o paciente tem um prontuário
               .HasForeignKey<ProntuarioModel>(p => p.PacienteId) // A FK fica no Prontuário
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            new ProntuarioModel
            {
                ProntuarioId = SeedDataConstants.PRONTUARIO_ID,
                PsicologoResponsavelId = SeedDataConstants.ESTUDANTE_ANA_ID,
                PacienteId = SeedDataConstants.PACIENTE_GALLO_ID,
                DataCriacao = new DateTime(2002, 4, 1),
                DataUltimaAtualizacao = new DateTime(2002, 4, 1),
                Queixas = "Paciente relata ansiedade e dificuldades para dormir.",
                TipoProntuario = Enums.TipoProntuarioEnum.Adulto
            });
      
    }
}