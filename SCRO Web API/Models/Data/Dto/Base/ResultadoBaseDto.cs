using Models.Extensions;

namespace SCRO_Web_API.Models.Data.Dto.Base;

public abstract class ResultadoBaseDto
{
    public int ResultadoId { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
    public int ValorResultadoClassificacao { get; set; }
    public int ResultadoCor { get; set; }
    public string ResultadoClassificacaoCor { get; set; }

}
