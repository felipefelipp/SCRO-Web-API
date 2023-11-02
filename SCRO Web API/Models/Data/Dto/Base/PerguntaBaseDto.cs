using Models.Classificacao;

namespace SCRO_Web_API.Models.Data.Dto.Base;

public class PerguntaBaseDto
{
    public string TextoPergunta { get; set; }
    public virtual CategoriaPergunta Categoria { get; set; }

}
