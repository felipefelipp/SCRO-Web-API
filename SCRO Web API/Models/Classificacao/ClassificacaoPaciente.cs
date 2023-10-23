using Models.Cliente;
using Models.Enums;
using Models.Extensions;

namespace Models.Classificacao;

public class ClassificacaoPaciente
{
    public int ClassificacaoPacienteId { get; set; }
    public int PacienteId { get; set; }
    public int ValorResultadoClassificacao { get; set; }
    public int ResultadoCor { get;  set; } 
    public ResultadoClassificacaoCor ResultadoClassificacaoCor
    {
        get { return ResultadoCor.ParaValorClassificacao(); }
        set { ResultadoCor = value.ParaIntClassificacao(); }
    }
}
