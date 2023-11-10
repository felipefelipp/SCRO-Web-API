using Models.Extensions;
using SCRO_Web_API.Models.Data.Dto.Base;

namespace SCRO_Web_API.Models.Data.Dto.RespostaDto;

public class ReadRespostaDto : RespostaBaseDto
{
    public int RespostaId { get; set; }
    public int ValorTipoResposta { get; set; }
    public string TipoResposta
    {
        get { return ValorTipoResposta.ParaValor().ToString(); }
    }
}
