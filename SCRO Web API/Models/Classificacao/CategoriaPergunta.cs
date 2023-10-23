namespace Models.Classificacao;

public class CategoriaPergunta
{
    public int CategoriaPerguntaId { get; set; }
    public virtual Pergunta Pergunta { get; set; }
    public int PerguntaId { get; set; }
    public string Descricao { get; set; }
}
