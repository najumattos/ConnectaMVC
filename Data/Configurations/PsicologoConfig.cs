using ConnectaMVC.Enums;
using ConnectaMVC.Helpers;
using ConnectaMVC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConnectaMVC.Data.Configurations;

public class PsicologoConfig : IEntityTypeConfiguration<PsicologoModel>
{
    public void Configure(EntityTypeBuilder<PsicologoModel> builder)
    {
        // 1. Define que o UsuarioId é a Chave Primária
        builder.HasKey(p => p.PsicologoId);

        // 2. Configura o relacionamento 1:1 com o Usuario
        builder.HasOne(p => p.Usuario)
               .WithOne() 
               .HasForeignKey<PsicologoModel>(p => p.UsuarioId)
               .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(

 new PsicologoModel
 {
     PsicologoId = SeedDataConstants.COORDENADOR_TAINARA_ID,
     UsuarioId = SeedDataConstants.USER_TAINARA_ID,
     RegistroAcademico = "1235545",
     Descricao = "LET TIME JUST FLYYYYY",
     TipoPerfil = TipoPerfilEnum.Coordenador
 },
 new PsicologoModel
 {
     PsicologoId = SeedDataConstants.ESTUDANTE_ANA_ID,
     UsuarioId = SeedDataConstants.USER_ANA_ID,
     RegistroAcademico = "12345",
     Descricao = "REBIRTH OF A MAN",
     TipoPerfil = TipoPerfilEnum.Estudante
 }
        );
    }
}
