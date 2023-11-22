using SCRO_Web_API.Models.Data.Dto.Base;

namespace SCRO_Web_API.Models.Data.Dto.AtendimentoDto;

public class ReadAtendimentoDto : AtendimentoBaseDto
{
    public int AtendimentoPacienteId { get; set; }
}
