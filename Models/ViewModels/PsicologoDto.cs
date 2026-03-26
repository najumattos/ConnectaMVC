using ConnectaMVC.Enums;

namespace ConnectaMVC.Models.ViewModels;

public class PsicologoDto
{
    public string CRP { get; set; }
    public string Descricao { get; set; }
    public TipoPerfilEnum TipoPerfil { get; set; }

}
