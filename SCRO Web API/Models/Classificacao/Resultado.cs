using Models.Enums;
using Models.Extensions;

namespace SCRO_Web_API.Models.Classificacao;

public class Resultado
{
    public int ValorResultadoClassificacao { get; set; }


    //[RegularExpression("^[12345]$", ErrorMessage = "Valor incorreto, preencha um dos valores: 1 - Vermelho, " +
    //                                                                                     "2 - Laranja, " +
    //                                                                                     "3 - Amarelo, " +
    //                                                                                     "4 - Verde, " ]
    public int ResultadoCor { get; set; }
    public ResultadoClassificacaoCor ResultadoClassificacaoCor
    {
        get { return ResultadoCor.ParaValorClassificacao(); }
        set { ResultadoCor = value.ParaIntClassificacao(); }
    }


}

