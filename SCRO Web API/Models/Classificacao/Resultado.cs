using Models.Enums;
using Models.Extensions;

namespace SCRO_Web_API.Models.Classificacao;

public class Resultado
{
    public int ResultadoId { get; set; }
    public int PacienteId { get; set; }
    public int ClassificacaoPacienteId { get; set; }
    public int ValorResultadoClassificacao { get; set; }
    public int ResultadoCor { get; set; }
    public string ResultadoClassificacaoCor { get; set; }
   

}

