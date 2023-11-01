using SCRO_Web_API.Models.Data.Dto.Base;
using SCRO_Web_API.Models.Data.Dto.ResponsavelDto;
using System.Runtime.Serialization;

namespace SCRO_Web_API.Models.Data.Dto.PacienteDto;

public class ReadPacienteDto : PacienteBaseDto
{

    public int PacienteId { get; set; }

    [DataMember(Order = 11)]
    public string SenhaClassificacao { get; set; }
}
