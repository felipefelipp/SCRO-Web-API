namespace Models.Classificacao;

public class Pergunta
{
    public int PerguntaId { get; set; }
    public string TextoPergunta { get; set; }
    public virtual CategoriaPergunta Categoria { get; set; }    
}

