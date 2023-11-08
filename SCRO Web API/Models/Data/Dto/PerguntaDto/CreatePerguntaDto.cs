using SCRO_Web_API.Models.Data.Dto.Base;

namespace SCRO_Web_API.Models.Data.Dto.PerguntaDto;

public class CreatePerguntaDto : PerguntaBaseDto
{
    public int CategoriaPerguntaId { get; set; }
}
