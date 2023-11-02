using SCRO_Web_API.Models.Data.Dto.Base;
using SCRO_Web_API.Models.Data.Dto.CategoriaPerguntaDto;

namespace SCRO_Web_API.Models.Data.Dto.PerguntaDto;

public class ReadPerguntaDto : PerguntaBaseDto
{
    public int PerguntaId { get; set; }
    public ReadCategoriaPerguntaDto CategoriaPergunta { get; set; }
}
