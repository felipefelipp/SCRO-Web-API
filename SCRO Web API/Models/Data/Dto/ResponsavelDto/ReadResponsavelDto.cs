using SCRO_Web_API.Models.Data.Dto.Base;
using SCRO_Web_API.Models.Data.Dto.PacienteDto;

namespace SCRO_Web_API.Models.Data.Dto.ResponsavelDto;

public class ReadResponsavelDto : ResponsavelBaseDto
{
    public int ResponsavelId { get; set; }
}
