using Models.Enums;

namespace Models.Extensions;

public static class ResultadoClassificacaoCorExtensions
{
     static Dictionary<int, ResultadoClassificacaoCor> Mapa = new Dictionary<int, ResultadoClassificacaoCor>() 
    {
        { 1, ResultadoClassificacaoCor.vermelho },
        { 2, ResultadoClassificacaoCor.laranja },
        { 3, ResultadoClassificacaoCor.amarelo },
        { 4, ResultadoClassificacaoCor.verde },
        { 5, ResultadoClassificacaoCor.azul }
    };

    public static int ParaIntClassificacao(this ResultadoClassificacaoCor valor) 
    {
        return Mapa.First(r => r.Value == valor).Key;
    }

    public static ResultadoClassificacaoCor ParaValorClassificacao(this int valor) 
    {
        return Mapa.First(r => r.Key == valor).Value;
    }
}
