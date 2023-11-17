using Models.Enums;

namespace Models.Extensions;

public static class ResultadoClassificacaoCorExtensions
{
    private static readonly List<(int valor, ResultadoClassificacaoCor cor)> Mapa = new List<(int, ResultadoClassificacaoCor)>() 
    {
        ( 40, ResultadoClassificacaoCor.vermelho ),
        ( 30, ResultadoClassificacaoCor.laranja ),
        ( 20, ResultadoClassificacaoCor.amarelo ),
        ( 10, ResultadoClassificacaoCor.verde ),
        ( 0, ResultadoClassificacaoCor.azul )
    };

    public static ResultadoClassificacaoCor ParaValorResultado(this int valor) 
    {
        foreach(var (limite, cor) in Mapa.OrderByDescending(x => x.valor))
        {
            if (valor >= limite)
            {
                return cor;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(valor), "O valor fornecido está fora do intervalo permitido.");
    }

    public static int ParaValorInt(this int valor)
    {
        foreach (var (limite, cor) in Mapa.OrderByDescending(x => x.valor))
        {
            if (valor >= limite)
            {
                return limite;
            }
        }

        throw new ArgumentOutOfRangeException(nameof(valor), "O valor fornecido está fora do intervalo permitido.");
    }

}
