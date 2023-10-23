using Models.Enums;

namespace Models.Extensions;

public static class TipoRespostaExtensions
{
     static Dictionary<int, TipoResposta> Mapa = new Dictionary<int, TipoResposta>()
    {
        { 1, TipoResposta.Text },
        { 2, TipoResposta.TextArea },
        { 3, TipoResposta.CheckBox },
        { 4, TipoResposta.ComboBox },
        { 5, TipoResposta.Radiobutton },
        { 6, TipoResposta.Data }
    };

    public static int ParaInt(this TipoResposta valor)
    {
        return Mapa.First(tr => tr.Value == valor).Key;
    }

    public static TipoResposta ParaValor(this int valor)
    {
        return Mapa.First(tr => tr.Key == valor).Value;
    }
}
